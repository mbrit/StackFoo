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
    /// Defines the entity type for 'Questions'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(QuestionItemCollection), "Questions")]
    public class QuestionItem : QuestionItemBase
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public QuestionItem()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected QuestionItem(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        internal void AddTag(TagItem tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            QuestionTagItem link = new QuestionTagItem();
            link.Question = this;
            link.Tag = tag;
            link.SaveChanges();
        }
    }
}
