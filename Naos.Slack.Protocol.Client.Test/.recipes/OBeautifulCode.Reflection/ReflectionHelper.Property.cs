﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.Property.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Reflection.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Reflection;

    using OBeautifulCode.Type.Recipes;

    using static global::System.FormattableString;

#if !OBeautifulCodeReflectionSolution
    internal
#else
    public
#endif
    static partial class ReflectionHelper
    {
        /// <summary>
        /// Gets the properties of the specified type,
        /// with various options to control the scope of properties included and optionally order the properties.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to <paramref name="type"/>.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberOwners">OPTIONAL value that scopes the search for members based on who owns the member.  DEFAULT is to include members owned by an object or owned by the type itself.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <param name="orderMembersBy">OPTIONAL value that specifies how to the members.  DEFAULT is return the members in no particular order.</param>
        /// <returns>
        /// The properties in the specified order.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        public static IReadOnlyList<PropertyInfo> GetPropertiesFiltered(
            this Type type,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberOwners memberOwners = MemberOwners.All,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated,
            OrderMembersBy orderMembersBy = OrderMembersBy.None)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var result = type
                .GetMembersFiltered(memberRelationships, memberOwners, memberAccessModifiers, MemberKinds.Property, memberMutability, memberAttributes, orderMembersBy)
                .Cast<PropertyInfo>()
                .ToList();

            return result;
        }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> for the specified property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to <paramref name="type"/>.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberOwners">OPTIONAL value that scopes the search for members based on who owns the member.  DEFAULT is to include members owned by an object or owned by the type itself.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <param name="throwIfNotFound">OPTIONAL value indicating whether to throw if no properties are found.  DEFAULT is to throw..</param>
        /// <returns>
        /// The <see cref="PropertyInfo"/> or null if no properties are found and <paramref name="throwIfNotFound"/> is false
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on the object type using the specified binding constraints and <paramref name="throwIfNotFound"/> is true.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        public static PropertyInfo GetPropertyFiltered(
            this Type type,
            string propertyName,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberOwners memberOwners = MemberOwners.All,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated,
            bool throwIfNotFound = true)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException(Invariant($"{nameof(propertyName)} is white space."));
            }

            var properties = type
                // ReSharper disable once RedundantArgumentDefaultValue
                .GetPropertiesFiltered(memberRelationships, memberOwners, memberAccessModifiers, memberMutability, memberAttributes, OrderMembersBy.None)
                .Where(_ => _.Name == propertyName)
                .ToList();

            PropertyInfo result;

            if (!properties.Any())
            {
                if (throwIfNotFound)
                {
                    throw new ArgumentException(Invariant($"There is no property named '{propertyName}' on type '{type.ToStringReadable()}', using the specified binding constraints."));
                }
                else
                {
                    result = null;
                }
            }
            else if (properties.Count > 1)
            {
                throw new ArgumentException(Invariant($"There is more than one property named '{propertyName}' on type '{type.ToStringReadable()}', using the specified binding constraints."));
            }
            else
            {
                result = properties.Single();
            }

            return result;
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="item">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to the <paramref name="item"/> Type.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberOwners">OPTIONAL value that scopes the search for members based on who owns the member.  DEFAULT is to include members owned by an object or owned by the type itself.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The property does not have a get method.</exception>
        /// <exception cref="InvalidCastException">The property is not of the specified type.</exception>
        public static T GetPropertyValue<T>(
            this object item,
            string propertyName,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberOwners memberOwners = MemberOwners.All,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var propertyInfo = item.GetType().GetPropertyFiltered(propertyName, memberRelationships, memberOwners, memberAccessModifiers, memberMutability, memberAttributes);

            var propertyValue = propertyInfo.GetValue(item);

            var result = propertyValue.CastOrThrowIfTypeMismatch<T>(propertyInfo);

            return result;
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <param name="item">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to the <paramref name="item"/> Type.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberOwners">OPTIONAL value that scopes the search for members based on who owns the member.  DEFAULT is to include members owned by an object or owned by the type itself.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The property does not have a get method.</exception>
        public static object GetPropertyValue(
            this object item,
            string propertyName,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberOwners memberOwners = MemberOwners.All,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var propertyInfo = item.GetType().GetPropertyFiltered(propertyName, memberRelationships, memberOwners, memberAccessModifiers, memberMutability, memberAttributes);

            var result = propertyInfo.GetValue(item);

            return result;
        }

        /// <summary>
        /// Gets the value of a static property.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="type">The type that contains the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to <paramref name="type"/>.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The property does not have a get method.</exception>
        /// <exception cref="InvalidCastException">The property is not of the specified type.</exception>
        public static T GetStaticPropertyValue<T>(
            this Type type,
            string propertyName,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var propertyInfo = type.GetPropertyFiltered(propertyName, memberRelationships, MemberOwners.Static, memberAccessModifiers, memberMutability, memberAttributes);

            var propertyValue = propertyInfo.GetValue(null);

            var result = propertyValue.CastOrThrowIfTypeMismatch<T>(propertyInfo);

            return result;
        }

        /// <summary>
        /// Gets the value of a property on a static type.
        /// </summary>
        /// <param name="type">The type that contains the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to <paramref name="type"/>.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The property does not have a get method.</exception>
        public static object GetStaticPropertyValue(
            this Type type,
            string propertyName,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var propertyInfo = type.GetPropertyFiltered(propertyName, memberRelationships, MemberOwners.Static, memberAccessModifiers, memberMutability, memberAttributes);

            var result = propertyInfo.GetValue(null);

            return result;
        }

        /// <summary>
        /// Determines if a type has a property of the specified property name.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="propertyName">The name of the property to check for.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to <paramref name="type"/>.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberOwners">OPTIONAL value that scopes the search for members based on who owns the member.  DEFAULT is to include members owned by an object or owned by the type itself.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <returns>
        /// true if the type has a property of the specified property name, false if not.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        public static bool HasProperty(
            this Type type,
            string propertyName,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberOwners memberOwners = MemberOwners.All,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException(Invariant($"{nameof(propertyName)} is white space."));
            }

            var properties = type
                // ReSharper disable once RedundantArgumentDefaultValue
                .GetPropertiesFiltered(memberRelationships, memberOwners, memberAccessModifiers, memberMutability, memberAttributes, OrderMembersBy.None)
                .Where(_ => _.Name == propertyName)
                .ToList();

            var result = properties.Any();

            return result;
        }

        /// <summary>
        /// Determines if the specified property is not writable (is read-only).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is not writable, otherwise false.
        /// </returns>
        public static bool IsNotWritableProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            var result = propertyInfo.IsReadOnlyProperty();

            return result;
        }

        /// <summary>
        /// Determines if the specified property is not readable (is write-only).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is not readable, otherwise false.
        /// </returns>
        public static bool IsNotReadableProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            var result = propertyInfo.IsWriteOnlyProperty();

            return result;
        }

        /// <summary>
        /// Determines if the specified property is readable (has a getter).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is readable, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyInfo"/> is null.</exception>
        public static bool IsReadableProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            var result = propertyInfo.GetMethod != null;

            return result;
        }

        /// <summary>
        /// Determines if the specified property is a read-only (has no setter).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is read-only, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyInfo"/> is null.</exception>
        public static bool IsReadOnlyProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            var result = propertyInfo.SetMethod == null;

            return result;
        }

        /// <summary>
        /// Determines if the specified property is a read-only auto property
        /// (i.e. MyProperty { get; }).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is a read-only auto-property, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyInfo"/> is null.</exception>
        public static bool IsReadOnlyAutoProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            // Is an auto-property (one with a backing field automatically generated by the compiler)?
            // Note that expression body properties are NOT auto-properties.
            // see: https://stackoverflow.com/a/60638810/356790
            var result = propertyInfo.IsReadOnlyProperty() && propertyInfo.GetMethod.IsCompilerGenerated();

            return result;
        }

        /// <summary>
        /// Determines if the specified property is writable (has a setter).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is writable, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyInfo"/> is null.</exception>
        public static bool IsWritableProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            var result = propertyInfo.SetMethod != null;

            return result;
        }

        /// <summary>
        /// Determines if the specified property is a write-only (has no getter).
        /// </summary>
        /// <param name="propertyInfo">The property.</param>
        /// <returns>
        /// true if the specified property is write-only, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyInfo"/> is null.</exception>
        public static bool IsWriteOnlyProperty(
            this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            var result = propertyInfo.GetMethod == null;

            return result;
        }

        /// <summary>
        /// Sets a property's value.
        /// </summary>
        /// <param name="item">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set the property to.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to the <paramref name="item"/> Type.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberOwners">OPTIONAL value that scopes the search for members based on who owns the member.  DEFAULT is to include members owned by an object or owned by the type itself.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="InvalidCastException">Unable to assign null to the property's type.</exception>
        /// <exception cref="InvalidCastException">Unable to assign <paramref name="value"/> type to the property's type.</exception>
        public static void SetPropertyValue(
            this object item,
            string propertyName,
            object value,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberOwners memberOwners = MemberOwners.All,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var propertyInfo = item.GetType().GetPropertyFiltered(propertyName, memberRelationships, memberOwners, memberAccessModifiers, memberMutability, memberAttributes);

            value.ThrowIfNotAssignableTo(propertyInfo);

            propertyInfo.SetValue(item, value);
        }

        /// <summary>
        /// Sets a static property's value.
        /// </summary>
        /// <param name="type">The type that contains the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set the property to.</param>
        /// <param name="memberRelationships">OPTIONAL value that scopes the search for members based on their relationship to <paramref name="type"/>.  DEFAULT is to include the members declared in or inherited by the specified type.</param>
        /// <param name="memberAccessModifiers">OPTIONAL value that scopes the search for members based on access modifiers.  DEFAULT is to include members having any supported access modifier.</param>
        /// <param name="memberMutability">OPTIONAL value that scopes the search for members based on mutability.  DEFAULT is to include members where mutability is not applicable and where applicable, include members with any kind of mutability.</param>
        /// <param name="memberAttributes">OPTIONAL value that scopes the search for members based on the presence or absence of certain attributes on those members.  DEFAULT is to include members that are not compiler generated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no property named <paramref name="propertyName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one property named <paramref name="propertyName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="InvalidCastException">Unable to assign null to the property's type.</exception>
        /// <exception cref="InvalidCastException">Unable to assign <paramref name="value"/> type to the property's type.</exception>
        public static void SetStaticPropertyValue(
            this Type type,
            string propertyName,
            object value,
            MemberRelationships memberRelationships = MemberRelationships.DeclaredOrInherited,
            MemberAccessModifiers memberAccessModifiers = MemberAccessModifiers.All,
            MemberMutability memberMutability = MemberMutability.All,
            MemberAttributes memberAttributes = MemberAttributes.NotCompilerGenerated)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var propertyInfo = type.GetPropertyFiltered(propertyName, memberRelationships, MemberOwners.Static, memberAccessModifiers, memberMutability, memberAttributes);

            value.ThrowIfNotAssignableTo(propertyInfo);

            propertyInfo.SetValue(null, value);
        }

        private static T CastOrThrowIfTypeMismatch<T>(
            this object propertyValue,
            PropertyInfo propertyInfo)
        {
            var returnType = typeof(T);

            T result;

            if (propertyValue == null)
            {
                // can't solely rely on the (T) cast - if pi.GetValue returns null, then null can be cast to any reference type.
                var propertyType = propertyInfo.PropertyType;

                if (!returnType.IsAssignableFrom(propertyType))
                {
                    throw new InvalidCastException(Invariant($"Unable to cast object of type '{propertyType.ToStringReadable()}' to type '{returnType.ToStringReadable()}'."));
                }

                result = default;
            }
            else
            {
                try
                {
                    result = (T)propertyValue;
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException(Invariant($"Unable to cast object of type '{propertyValue.GetType().ToStringReadable()}' to type '{returnType.ToStringReadable()}'."));
                }
            }

            return result;
        }

        private static void ThrowIfNotAssignableTo(
            this object value,
            PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (value == null)
            {
                if (!propertyType.IsClosedTypeAssignableToNull())
                {
                    throw new InvalidCastException(Invariant($"Unable to assign null value to property of type '{propertyType.ToStringReadable()}'."));
                }
            }
            else
            {
                var valueType = value.GetType();

                if (!propertyType.IsAssignableFrom(valueType))
                {
                    throw new InvalidCastException(Invariant($"Unable to assign value of type '{valueType.ToStringReadable()}' to property of type '{propertyType.ToStringReadable()}'."));
                }
            }
        }
    }
}