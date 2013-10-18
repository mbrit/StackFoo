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
    /// Defines the base entity type for 'Questions'.
    /// </summary>
    [Serializable()]
    [Index("Questions_NativeId", "Questions_NativeId", true, "NativeId")]
    public abstract class QuestionItemBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected QuestionItemBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected QuestionItemBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'QuestionId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'QuestionId' column.
        /// </remarks>
        [EntityField("QuestionId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
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
        /// Gets or sets the value for 'NativeId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'NativeId' column.
        /// </remarks>
        [EntityField("NativeId", System.Data.DbType.Int64, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public long NativeId
        {
            get
            {
                return ((long)(this["NativeId"]));
            }
            set
            {
                this["NativeId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Title'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Title' column.
        /// </remarks>
        [EntityField("Title", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 128)]
        public string Title
        {
            get
            {
                return ((string)(this["Title"]));
            }
            set
            {
                this["Title"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'DateTime'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'DateTime' column.
        /// </remarks>
        [EntityField("DateTime", System.Data.DbType.DateTime, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public System.DateTime DateTime
        {
            get
            {
                return ((System.DateTime)(this["DateTime"]));
            }
            set
            {
                this["DateTime"] = value;
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'QuestionItem'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'QuestionItem'.
        /// </summary>
        public static void SetProperties(int questionId, string[] propertyNames, object[] propertyValues)
        {
            QuestionItem entity = Br.StackFoo.QuestionItem.GetById(questionId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="QuestionItem"/> entities.
        /// </summary>
        public static QuestionItemCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(QuestionItem));
            return ((QuestionItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionItem
        /// </bootfx>
        public static QuestionItem GetById(int questionId)
        {
            return Br.StackFoo.QuestionItem.GetById(questionId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static QuestionItem GetById(int questionId, BootFX.Common.Data.SqlOperator questionIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("QuestionId", questionIdOperator, questionId);
            return ((QuestionItem)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionItem
        /// </bootfx>
        public static QuestionItem GetById(int questionId, BootFX.Common.OnNotFound onNotFound)
        {
            return Br.StackFoo.QuestionItem.GetById(questionId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="QuestionItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static QuestionItem GetById(int questionId, BootFX.Common.Data.SqlOperator questionIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("QuestionId", questionIdOperator, questionId);
            QuestionItem results = ((QuestionItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where NativeId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionItem
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>Questions_NativeId</c>.
        /// </remarks>
        public static QuestionItem GetByNativeId(long nativeId)
        {
            return Br.StackFoo.QuestionItem.GetByNativeId(nativeId, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where NativeId is equal to the given value.
        /// </summary>
        /// <remarks>
        /// Created for index <c>Questions_NativeId</c>.
        /// </remarks>
        public static QuestionItem GetByNativeId(long nativeId, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("NativeId", BootFX.Common.Data.SqlOperator.EqualTo, nativeId);
            QuestionItem results = ((QuestionItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Title is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Title</c>
        /// </remarks>
        public static QuestionItemCollection GetByTitle(string title)
        {
            return Br.StackFoo.QuestionItem.GetByTitle(title, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Title matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Title</c>
        /// </remarks>
        public static QuestionItemCollection GetByTitle(string title, BootFX.Common.Data.SqlOperator titleOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("Title", titleOperator, title);
            return ((QuestionItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Title matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Title</c>
        /// </remarks>
        public static QuestionItemCollection GetByTitle(string title, BootFX.Common.Data.SqlOperator titleOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("Title", titleOperator, title);
            QuestionItemCollection results = ((QuestionItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where DateTime is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - QuestionItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>DateTime</c>
        /// </remarks>
        public static QuestionItemCollection GetByDateTime(System.DateTime dateTime)
        {
            return Br.StackFoo.QuestionItem.GetByDateTime(dateTime, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where DateTime matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>DateTime</c>
        /// </remarks>
        public static QuestionItemCollection GetByDateTime(System.DateTime dateTime, BootFX.Common.Data.SqlOperator dateTimeOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("DateTime", dateTimeOperator, dateTime);
            return ((QuestionItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where DateTime matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>DateTime</c>
        /// </remarks>
        public static QuestionItemCollection GetByDateTime(System.DateTime dateTime, BootFX.Common.Data.SqlOperator dateTimeOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionItem));
            filter.Constraints.Add("DateTime", dateTimeOperator, dateTime);
            QuestionItemCollection results = ((QuestionItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Get all of the child 'QuestionTagItem' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>Question</c>.  (Stub method.)
        /// </remarks>
        public QuestionTagItemCollection GetQuestionTagItemItems()
        {
            // defer...
            return QuestionItem.GetQuestionTagItemItems(this.QuestionId);
        }
        
        /// <summary>
        /// Get all of the child 'QuestionTagItem' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>Question</c>.  (Concrete method.)
        /// </remarks>
        public static QuestionTagItemCollection GetQuestionTagItemItems(int questionId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("QuestionId", BootFX.Common.Data.SqlOperator.EqualTo, questionId);
            return ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Searches for <see cref="QuestionItem"/> items with the given terms.
        /// </summary>
        public static QuestionItemCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(QuestionItem), terms);
            return ((QuestionItemCollection)(searcher.ExecuteEntityCollection()));
        }
    }
}
