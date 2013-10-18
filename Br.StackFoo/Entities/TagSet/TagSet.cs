namespace Br.StackFoo
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using BootFX.Common;
    using BootFX.Common.Data;
    using BootFX.Common.Entities;
    using BootFX.Common.Entities.Attributes;
    using BootFX.Common.BusinessServices;
    
    
    /// <summary>
    /// Defines the entity type for 'TagSets'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(TagSetCollection), "TagSets")]
    [SortSpecification(new string[] {
            "Name"}, new BootFX.Common.Data.SortDirection[] {
            BootFX.Common.Data.SortDirection.Ascending})]
    public class TagSet : TagSetBase
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public TagSet()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected TagSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        internal static void CheckTagSets()
        {
            if (!(TagSet.GetAll().Any()))
            {
                CreateTagSet("android", "android");
                CreateTagSet("ios", "ios, ipad, iphone, objective-c");
                CreateTagSet("windows phone", "windows-phone");
                CreateTagSet("wsa", "windows-store, winrt, windows-runtime");
            }
        }

        private static void CreateTagSet(string name, string tags)
        {
            var tagSet = new TagSet()
            {
                Name = name,
                Tags = tags
            };
            tagSet.SaveChanges();
        }
    }
}
