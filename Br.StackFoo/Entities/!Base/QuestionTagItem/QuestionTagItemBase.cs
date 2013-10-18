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
    /// Defines the base entity type for 'QuestionTags'.
    /// </summary>
    [Serializable()]
    [Index("QuestionTags_QuestionTag", "QuestionTags_QuestionTag", true, "QuestionId,TagId")]
    public abstract class QuestionTagItemBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected QuestionTagItemBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected QuestionTagItemBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'LinkId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LinkId' column.
        /// </remarks>
        [EntityField("LinkId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
        public int LinkId
        {
            get
            {
                return ((int)(this["LinkId"]));
            }
            set
            {
                this["LinkId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'QuestionId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'QuestionId' column.
        /// </remarks>
        [EntityField("QuestionId", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DBNullEquivalent(0)]
        public int QuestionId
        {
            get
            {
                return ((int)(this["QuestionId"]));
            }
            set
            {
                this["QuestionId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'TagId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'TagId' column.
        /// </remarks>
        [EntityField("TagId", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DBNullEquivalent(0)]
        public int TagId
        {
            get
            {
                return ((int)(this["TagId"]));
            }
            set
            {
                this["TagId"] = value;
            }
        }
        
        /// <summary>
        /// Gets the link to 'QuestionItem'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_QuestionTags_Questions' constraint.
        /// </remarks>
        [EntityLinkToParent("Question", "FK_QuestionTags_Questions", typeof(QuestionItem), new string[] {
                "QuestionId"})]
        public QuestionItem Question
        {
            get
            {
                return ((QuestionItem)(this.GetParent("Question")));
            }
            set
            {
                this.SetParent("Question", value);
            }
        }
        
        /// <summary>
        /// Gets the link to 'TagItem'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_QuestionTags_Tags' constraint.
        /// </remarks>
        [EntityLinkToParent("Tag", "FK_QuestionTags_Tags", typeof(TagItem), new string[] {
                "TagId"})]
        public TagItem Tag
        {
            get
            {
                return ((TagItem)(this.GetParent("Tag")));
            }
            set
            {
                this.SetParent("Tag", value);
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'QuestionTagItem'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'QuestionTagItem'.
        /// </summary>
        public static void SetProperties(int linkId, string[] propertyNames, object[] propertyValues)
        {
            QuestionTagItem entity = Br.StackFoo.QuestionTagItem.GetById(linkId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="QuestionTagItem"/> entities.
        /// </summary>
        public static QuestionTagItemCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(QuestionTagItem));
            return ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionTagItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionTagItem
        /// </bootfx>
        public static QuestionTagItem GetById(int linkId)
        {
            return Br.StackFoo.QuestionTagItem.GetById(linkId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionTagItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static QuestionTagItem GetById(int linkId, BootFX.Common.Data.SqlOperator linkIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("LinkId", linkIdOperator, linkId);
            return ((QuestionTagItem)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionTagItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionTagItem
        /// </bootfx>
        public static QuestionTagItem GetById(int linkId, BootFX.Common.OnNotFound onNotFound)
        {
            return Br.StackFoo.QuestionTagItem.GetById(linkId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionTagItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static QuestionTagItem GetById(int linkId, BootFX.Common.Data.SqlOperator linkIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("LinkId", linkIdOperator, linkId);
            QuestionTagItem results = ((QuestionTagItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where QuestionId and TagId are equal to the given values.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionTagItem
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>QuestionTags_QuestionTag</c>.
        /// </remarks>
        public static QuestionTagItem GetByQuestionIdAndTagId(int questionId, int tagId)
        {
            return Br.StackFoo.QuestionTagItem.GetByQuestionIdAndTagId(questionId, tagId, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where QuestionId and TagId are equal to the given values.
        /// </summary>
        /// <remarks>
        /// Created for index <c>QuestionTags_QuestionTag</c>.
        /// </remarks>
        public static QuestionTagItem GetByQuestionIdAndTagId(int questionId, int tagId, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("QuestionId", BootFX.Common.Data.SqlOperator.EqualTo, questionId);
            filter.Constraints.Add("TagId", BootFX.Common.Data.SqlOperator.EqualTo, tagId);
            QuestionTagItem results = ((QuestionTagItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where QuestionId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionTagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>QuestionId</c>
        /// </remarks>
        public static QuestionTagItemCollection GetByQuestionId(int questionId)
        {
            return Br.StackFoo.QuestionTagItem.GetByQuestionId(questionId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where QuestionId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>QuestionId</c>
        /// </remarks>
        public static QuestionTagItemCollection GetByQuestionId(int questionId, BootFX.Common.Data.SqlOperator questionIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("QuestionId", questionIdOperator, questionId);
            return ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where QuestionId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>QuestionId</c>
        /// </remarks>
        public static QuestionTagItemCollection GetByQuestionId(int questionId, BootFX.Common.Data.SqlOperator questionIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("QuestionId", questionIdOperator, questionId);
            QuestionTagItemCollection results = ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where TagId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionTagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>TagId</c>
        /// </remarks>
        public static QuestionTagItemCollection GetByTagId(int tagId)
        {
            return Br.StackFoo.QuestionTagItem.GetByTagId(tagId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where TagId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>TagId</c>
        /// </remarks>
        public static QuestionTagItemCollection GetByTagId(int tagId, BootFX.Common.Data.SqlOperator tagIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("TagId", tagIdOperator, tagId);
            return ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where TagId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>TagId</c>
        /// </remarks>
        public static QuestionTagItemCollection GetByTagId(int tagId, BootFX.Common.Data.SqlOperator tagIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("TagId", tagIdOperator, tagId);
            QuestionTagItemCollection results = ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Searches for <see cref="QuestionTagItem"/> items with the given terms.
        /// </summary>
        public static QuestionTagItemCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(QuestionTagItem), terms);
            return ((QuestionTagItemCollection)(searcher.ExecuteEntityCollection()));
        }
    }
}
