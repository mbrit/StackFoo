namespace Br.StackFoo
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Collections;
    using System.Collections.Specialized;
    using BootFX.Common;
    using BootFX.Common.Data;
    using BootFX.Common.Entities;
    using BootFX.Common.Entities.Attributes;
    using BootFX.Common.BusinessServices;
    
    
    /// <summary>
    /// Defines the entity type for 'Tags'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(TagItemCollection), "Tags")]
    [SortSpecification(new string[] {
            "Name"}, new BootFX.Common.Data.SortDirection[] {
            BootFX.Common.Data.SortDirection.Ascending})]
    public class TagItem : TagItemBase
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public TagItem()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected TagItem(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
    }
}
