// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstructorArgumentXmlElementProcessor.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Jason Leonard (jason@intensepurple.co.uk)
//            Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Xml.Processors
{
    using System.Linq;
    using System.Xml.Linq;

    using Ninject.Extensions.Xml.Extensions;
    using Ninject.Planning.Bindings;

    /// <summary>
    /// Processor for constructorArgument elements.
    /// </summary>
    public class ConstructorArgumentXmlElementProcessor : AbstractXmlElementProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorArgumentXmlElementProcessor"/> class.
        /// </summary>
        public ConstructorArgumentXmlElementProcessor()
            : base("constructorArgument", Enumerable.Empty<string>(), "ConstructorArgument")
        {
        }

        /// <summary>
        /// Processes the specified element.
        /// </summary>
        /// <param name="element">The element that shall be processed.</param>
        /// <param name="owner">The owner of this instance.</param>
        /// <param name="bindingSyntax">The binding syntax.</param>
        public override void Process(XElement element, IOwnXmlNodeProcessor owner, IBindingConfigurationSyntax<object> bindingSyntax)
        {
            var name = element.RequiredAttribute("name");
            var value = element.RequiredAttribute("value");
            bindingSyntax.WithConstructorArgument(name.Value, value.Value);
        }

        /// <summary>
        /// Specifies if the processor applies to the given owner.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>
        /// True if the processor is a applicable processor for the specified owner.
        /// </returns>
        public override bool AppliesTo(IOwnXmlNodeProcessor owner)
        {
            // constructorArgument element is applied to the bind element.
            return base.AppliesTo(owner) || owner.XmlNodeName == "bind";
        }
    }
}
