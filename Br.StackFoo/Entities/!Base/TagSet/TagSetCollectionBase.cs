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
    /// Defines the base collection for entities of type <see cref="TagSet"/>.
    /// </summary>
    [Serializable()]
    public abstract class TagSetCollectionBase : BootFX.Common.Entities.EntityCollection, IEnumerable<TagSet>
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TagSetCollectionBase() : 
                base(typeof(TagSet))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected TagSetCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public TagSet this[int index]
        {
            get
            {
                return ((TagSet)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="TagSet"/> instance to the collection.
        /// </summary>
        public int Add(TagSet item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="TagSet"/> instances to the collection.
        /// </summary>
        public void AddRange(TagSet[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="TagSet"/> instances to the collection.
        /// </summary>
        public void AddRange(TagSetCollection items)
        {
            base.AddRange(items);
        }
        
        IEnumerator<TagSet> IEnumerable<TagSet>.GetEnumerator()
        {
            return this.GetEnumerator<TagSet>();
        }
    }
}
