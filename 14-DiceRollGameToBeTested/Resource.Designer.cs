﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("14-DiceRollGameToBeTested.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string EnterNumberMessage {
            get {
                return ResourceManager.GetString("EnterNumberMessage", resourceCulture);
            }
        }
        
        public static string GameStartMessage {
            get {
                return ResourceManager.GetString("GameStartMessage", resourceCulture);
            }
        }
        
        public static string WrongNumberMessage {
            get {
                return ResourceManager.GetString("WrongNumberMessage", resourceCulture);
            }
        }
        
        public static string VictoryMessage {
            get {
                return ResourceManager.GetString("VictoryMessage", resourceCulture);
            }
        }
        
        public static string LossMessage {
            get {
                return ResourceManager.GetString("LossMessage", resourceCulture);
            }
        }
    }
}
