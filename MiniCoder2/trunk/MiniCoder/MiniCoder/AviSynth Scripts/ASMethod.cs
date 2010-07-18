using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ASScript {
    /// <summary>
    /// An AviSynth method.
    /// </summary>
    public class ASMethod {
        public ASMethod(string name) {
            this.Name = name;
            this.Description = String.Empty;
        }

        /// <summary>
        /// The name of the method.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The MediaWiki URL of the method.
        /// </summary>
        public readonly string WikiUrl {
            get {
                return "http://avisynth.org/mediawiki/" + this.Name;
            }
        }

        private List<ASArgument> _Arguments = new List<ASArgument>();

        /// <summary>
        /// The method's arguments.
        /// </summary>
        public readonly List<ASArgument> Arguments { get { return _Arguments; } }

    }

    /// <summary>
    /// An AviSynth method argument.
    /// </summary>
    public struct ASArgument {
        public ASArgument(string name, ASType type) {
            this.Name = name;
            this.Type = type;
        }

        public ASType Type { get; set; }
        public string Name { get; set; }
        public bool IsParamArray { get; set; }
    }

    /// <summary>
    /// An AviSynth type.
    /// </summary>
    public enum ASType { @bool, @int, @float, @string, clip }
}