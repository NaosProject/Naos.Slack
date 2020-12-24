﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberRelationships.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Reflection.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes
{
    using global::System;

    /// <summary>
    /// Scopes the search for members based on their relationship to a specified type.
    /// </summary>
    [Flags]
#if !OBeautifulCodeReflectionSolution
    [global::System.CodeDom.Compiler.GeneratedCode("OBeautifulCode.Reflection.Recipes", "See package version number")]
    internal
#else
    public
#endif
    enum MemberRelationships
    {
        /// <summary>
        /// None (default).
        /// </summary>
        None = 0,

        /// <summary>
        /// Include members declared in the specified type.
        /// </summary>
        DeclaredInType = 1,

        /// <summary>
        /// Include members inherited by the specified type.
        /// Private members of base types are not inherited and would not be
        /// returned when using this flag; <see cref="DeclaredInAncestorTypes"/>.
        /// </summary>
        InheritedByType = 2,

        /// <summary>
        /// Include members declared in all ancestor types.
        /// This would include private members of base types.
        /// </summary>
        DeclaredInAncestorTypes = 4,

        /// <summary>
        /// Include members declared in all interfaces implemented by the specified type.
        /// </summary>
        DeclaredInImplementedInterfaceTypes = 8,

        /// <summary>
        /// Include members declared in or inherited by the specified type.
        /// </summary>
        DeclaredOrInherited = DeclaredInType | InheritedByType,

        /// <summary>
        /// Include members that are declared in the specified type or declared in all ancestor types.
        /// </summary>
        DeclaredInTypeOrAncestorTypes = DeclaredInType | DeclaredInAncestorTypes,

        /// <summary>
        /// Include members that are declared in the specified type or are declared in all interfaces implemented by the specified type.
        /// </summary>
        DeclaredInTypeOrImplementedInterfaces = DeclaredInType | DeclaredInImplementedInterfaceTypes,
    }
}