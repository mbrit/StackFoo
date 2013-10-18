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
    /// Defines the base collection for entities of type <see cref="QuestionTagItem"/>.
    /// </summary>
    [Serializable()]
    public abstract class QuestionTagItemCollectionBase : BootFX.Common.Entities.EntityCollection, IEnumerable<QuestionTagItem>
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected QuestionTagItemCollectionBase() : 
                base(typeof(QuestionTagItem))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected QuestionTagItemCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public QuestionTagItem this[int index]
        {
            get
            {
                return ((QuestionTagItem)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="QuestionTagItem"/> instance to the collection.
        /// </summary>
        public int Add(QuestionTagItem item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="QuestionTagItem"/> instances to the collection.
        /// </summary>
        public void AddRange(QuestionTagItem[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="QuestionTagItem"/> instances to the collection.
        /// </summary>
        public void AddRange(QuestionTagItemCollection items)
        {
            base.AddRange(items);
        }
        
        IEnumerator<QuestionTagItem> IEnumerable<QuestionTagItem>.GetEnumerator()
        {
            return this.GetEnumerator<QuestionTagItem>();
        }
    }
}
