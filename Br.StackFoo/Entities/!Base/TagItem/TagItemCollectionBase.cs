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
    /// Defines the base collection for entities of type <see cref="TagItem"/>.
    /// </summary>
    [Serializable()]
    public abstract class TagItemCollectionBase : BootFX.Common.Entities.EntityCollection, IEnumerable<TagItem>
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TagItemCollectionBase() : 
                base(typeof(TagItem))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected TagItemCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public TagItem this[int index]
        {
            get
            {
                return ((TagItem)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="TagItem"/> instance to the collection.
        /// </summary>
        public int Add(TagItem item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="TagItem"/> instances to the collection.
        /// </summary>
        public void AddRange(TagItem[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="TagItem"/> instances to the collection.
        /// </summary>
        public void AddRange(TagItemCollection items)
        {
            base.AddRange(items);
        }
        
        IEnumerator<TagItem> IEnumerable<TagItem>.GetEnumerator()
        {
            return this.GetEnumerator<TagItem>();
        }
    }
}
