﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Library.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Results {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Results() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("E_Library.Resources.Results", typeof(Results).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wybrana książka znajduje sięna liście życzeń użytkownika.
        /// </summary>
        public static string book_already_on_wihslist {
            get {
                return ResourceManager.GetString("book_already_on_wihslist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operacja nie może zostać wykonana, egzemplarz książki został już zwrócony.
        /// </summary>
        public static string can_not_return_free_copy {
            get {
                return ResourceManager.GetString("can_not_return_free_copy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wybrana książka nie znajduje się na liście zostać użytkownika, nie może zostać z niej usunięta.
        /// </summary>
        public static string no_book_on_wihslist {
            get {
                return ResourceManager.GetString("no_book_on_wihslist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nie znaleziono książki o żądanym identyfikatorze.
        /// </summary>
        public static string not_found_book {
            get {
                return ResourceManager.GetString("not_found_book", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nie znaleziono egzemplarza książki o podanymy identyfikatorze.
        /// </summary>
        public static string not_found_book_copy {
            get {
                return ResourceManager.GetString("not_found_book_copy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wypożyczenie niemożliwe - aktualnie nie ma wolnego egzemplarza żądanej książki.
        /// </summary>
        public static string not_found_free_book_copy {
            get {
                return ResourceManager.GetString("not_found_free_book_copy", resourceCulture);
            }
        }
    }
}
