﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FastMember;
using Microsoft.EntityFrameworkCore;

namespace Des.EntityFrameworkCore.Extensions
{
    internal class ObjectReaderEx : ObjectReader // Overridden to fix ShadowProperties in FastMember library
    {
        private readonly HashSet<string> _shadowProperties;
        private readonly DbContext _context;
        private string[] _members;
        private FieldInfo _current;

        public ObjectReaderEx(Type type, IEnumerable source, HashSet<string> shadowProperties, DbContext context, params string[] members) : base(type, source, members)
        {
            _shadowProperties = shadowProperties;
            _context = context;
            _members = members;
            _current = typeof(ObjectReader).GetField("current", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static ObjectReader Create<T>(IEnumerable<T> source, HashSet<string> shadowProperties, DbContext context, params string[] members)
        {
            bool hasShadowProp = shadowProperties.Count > 0;
            return hasShadowProp ? (ObjectReader)new ObjectReaderEx(typeof(T), source, shadowProperties, context, members) : ObjectReader.Create(source, members);
        }

        public override object this[string name]
        {
            get
            {
                if (_shadowProperties.Contains(name))
                {
                    var current = _current.GetValue(this);
                    return _context.Entry(current).Property(name).CurrentValue;
                }
                return base[name];
            }
        }

        public override object this[int i]
        {
            get
            {
                var name = _members[i];
                return this[name];
            }
        }
    }
}
