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
    /// Defines the base collection for entities of type <see cref="QuestionItem"/>.
    /// </summary>
    [Serializable()]
    public abstract class QuestionItemCollectionBase : BootFX.Common.Entities.EntityCollection, IEnumerable<QuestionItem>
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected QuestionItemCollectionBase() : 
                base(typeof(QuestionItem))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected QuestionItemCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public QuestionItem this[int index]
        {
            get
            {
                return ((QuestionItem)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="QuestionItem"/> instance to the collection.
        /// </summary>
        public int Add(QuestionItem item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="QuestionItem"/> instances to the collection.
        /// </summary>
        public void AddRange(QuestionItem[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="QuestionItem"/> instances to the collection.
        /// </summary>
        public void AddRange(QuestionItemCollection items)
        {
            base.AddRange(items);
        }
        
        IEnumerator<QuestionItem> IEnumerable<QuestionItem>.GetEnumerator()
        {
            return this.GetEnumerator<QuestionItem>();
        }
    }
}
