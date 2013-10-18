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
    /// Defines the entity type for 'QuestionTags'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(QuestionTagItemCollection), "QuestionTags")]
    public class QuestionTagItem : QuestionTagItemBase
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public QuestionTagItem()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected QuestionTagItem(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
    }
}
