﻿namespace Newbe.ObjectVisitor
{
    /// <summary>
    /// cache
    /// </summary>
    public static class CacheExtensions
    {
        public static ICachedObjectVisitor<T> Cache<T>(this IOvBuilderContext<T> builderContext)
        {
            var visitor = builderContext.CreateVisitor();
            return new CachedObjectVisitor<T>(visitor);
        }

        public static ICachedObjectVisitor<T, TExtend> Cache<T, TExtend>(
            this IOvBuilderContext<T, TExtend> builderContext)
        {
            var visitor = builderContext.CreateVisitor();
            return new CachedObjectVisitor<T, TExtend>(visitor);
        }

        public static void Run<T>(this ICachedObjectVisitor<T> visitor, T obj)
        {
            visitor.Action.Invoke(obj);
        }

        public static void Run<T, TExtend>(this ICachedObjectVisitor<T, TExtend> visitor, T obj, TExtend extendObj)
        {
            visitor.Action.Invoke(obj, extendObj);
        }
    }
}