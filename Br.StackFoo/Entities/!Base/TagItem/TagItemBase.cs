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
    /// Defines the base entity type for 'Tags'.
    /// </summary>
    [Serializable()]
    [Index("Tags_Tag", "Tags_Tag", true, "Name")]
    public abstract class TagItemBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TagItemBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected TagItemBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'TagId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'TagId' column.
        /// </remarks>
        [EntityField("TagId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
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
        /// Gets or sets the value for 'Name'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Name' column.
        /// </remarks>
        [EntityField("Name", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
        public string Name
        {
            get
            {
                return ((string)(this["Name"]));
            }
            set
            {
                this["Name"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'IsActive'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'IsActive' column.
        /// </remarks>
        [EntityField("IsActive", System.Data.DbType.Boolean, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public bool IsActive
        {
            get
            {
                return ((bool)(this["IsActive"]));
            }
            set
            {
                this["IsActive"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'LastCount'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LastCount' column.
        /// </remarks>
        [EntityField("LastCount", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public int LastCount
        {
            get
            {
                return ((int)(this["LastCount"]));
            }
            set
            {
                this["LastCount"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'NextUpdateUtc'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'NextUpdateUtc' column.
        /// </remarks>
        [EntityField("NextUpdateUtc", System.Data.DbType.DateTime, (BootFX.Common.Entities.EntityFieldFlags.Nullable | BootFX.Common.Entities.EntityFieldFlags.Common))]
        public System.DateTime NextUpdateUtc
        {
            get
            {
                return ((System.DateTime)(this["NextUpdateUtc"]));
            }
            set
            {
                this["NextUpdateUtc"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'LastOk'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LastOk' column.
        /// </remarks>
        [EntityField("LastOk", System.Data.DbType.Boolean, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DatabaseDefault(BootFX.Common.Data.Schema.SqlDatabaseDefaultType.Primitive, 1)]
        public bool LastOk
        {
            get
            {
                return ((bool)(this["LastOk"]));
            }
            set
            {
                this["LastOk"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'LastError'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LastError' column.
        /// </remarks>
        [EntityField("LastError", System.Data.DbType.String, (BootFX.Common.Entities.EntityFieldFlags.Nullable | BootFX.Common.Entities.EntityFieldFlags.Large))]
        public string LastError
        {
            get
            {
                return ((string)(this["LastError"]));
            }
            set
            {
                this["LastError"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'ForceActive'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'ForceActive' column.
        /// </remarks>
        [EntityField("ForceActive", System.Data.DbType.Boolean, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DatabaseDefault(BootFX.Common.Data.Schema.SqlDatabaseDefaultType.Primitive, 0)]
        public bool ForceActive
        {
            get
            {
                return ((bool)(this["ForceActive"]));
            }
            set
            {
                this["ForceActive"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'LastUpdateUtc'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LastUpdateUtc' column.
        /// </remarks>
        [EntityField("LastUpdateUtc", System.Data.DbType.DateTime, (BootFX.Common.Entities.EntityFieldFlags.Nullable | BootFX.Common.Entities.EntityFieldFlags.Common))]
        public System.DateTime LastUpdateUtc
        {
            get
            {
                return ((System.DateTime)(this["LastUpdateUtc"]));
            }
            set
            {
                this["LastUpdateUtc"] = value;
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'TagItem'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(TagItem));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'TagItem'.
        /// </summary>
        public static void SetProperties(int tagId, string[] propertyNames, object[] propertyValues)
        {
            TagItem entity = Br.StackFoo.TagItem.GetById(tagId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="TagItem"/> entities.
        /// </summary>
        public static TagItemCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(TagItem));
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="TagItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        public static TagItem GetById(int tagId)
        {
            return Br.StackFoo.TagItem.GetById(tagId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="TagItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static TagItem GetById(int tagId, BootFX.Common.Data.SqlOperator tagIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("TagId", tagIdOperator, tagId);
            return ((TagItem)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="TagItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        public static TagItem GetById(int tagId, BootFX.Common.OnNotFound onNotFound)
        {
            return Br.StackFoo.TagItem.GetById(tagId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="TagItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static TagItem GetById(int tagId, BootFX.Common.Data.SqlOperator tagIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("TagId", tagIdOperator, tagId);
            TagItem results = ((TagItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where Name is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>Tags_Tag</c>.
        /// </remarks>
        public static TagItem GetByName(string name)
        {
            return Br.StackFoo.TagItem.GetByName(name, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where Name is equal to the given value.
        /// </summary>
        /// <remarks>
        /// Created for index <c>Tags_Tag</c>.
        /// </remarks>
        public static TagItem GetByName(string name, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("Name", BootFX.Common.Data.SqlOperator.EqualTo, name);
            TagItem results = ((TagItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where IsActive is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static TagItemCollection GetByIsActive(bool isActive)
        {
            return Br.StackFoo.TagItem.GetByIsActive(isActive, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where IsActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static TagItemCollection GetByIsActive(bool isActive, BootFX.Common.Data.SqlOperator isActiveOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("IsActive", isActiveOperator, isActive);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where IsActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static TagItemCollection GetByIsActive(bool isActive, BootFX.Common.Data.SqlOperator isActiveOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("IsActive", isActiveOperator, isActive);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where LastCount is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>LastCount</c>
        /// </remarks>
        public static TagItemCollection GetByLastCount(int lastCount)
        {
            return Br.StackFoo.TagItem.GetByLastCount(lastCount, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where LastCount matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastCount</c>
        /// </remarks>
        public static TagItemCollection GetByLastCount(int lastCount, BootFX.Common.Data.SqlOperator lastCountOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastCount", lastCountOperator, lastCount);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where LastCount matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastCount</c>
        /// </remarks>
        public static TagItemCollection GetByLastCount(int lastCount, BootFX.Common.Data.SqlOperator lastCountOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastCount", lastCountOperator, lastCount);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where NextUpdateUtc is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>NextUpdateUtc</c>
        /// </remarks>
        public static TagItemCollection GetByNextUpdateUtc(System.DateTime nextUpdateUtc)
        {
            return Br.StackFoo.TagItem.GetByNextUpdateUtc(nextUpdateUtc, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where NextUpdateUtc matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>NextUpdateUtc</c>
        /// </remarks>
        public static TagItemCollection GetByNextUpdateUtc(System.DateTime nextUpdateUtc, BootFX.Common.Data.SqlOperator nextUpdateUtcOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("NextUpdateUtc", nextUpdateUtcOperator, nextUpdateUtc);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where NextUpdateUtc matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>NextUpdateUtc</c>
        /// </remarks>
        public static TagItemCollection GetByNextUpdateUtc(System.DateTime nextUpdateUtc, BootFX.Common.Data.SqlOperator nextUpdateUtcOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("NextUpdateUtc", nextUpdateUtcOperator, nextUpdateUtc);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where LastOk is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>LastOk</c>
        /// </remarks>
        public static TagItemCollection GetByLastOk(bool lastOk)
        {
            return Br.StackFoo.TagItem.GetByLastOk(lastOk, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where LastOk matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastOk</c>
        /// </remarks>
        public static TagItemCollection GetByLastOk(bool lastOk, BootFX.Common.Data.SqlOperator lastOkOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastOk", lastOkOperator, lastOk);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where LastOk matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastOk</c>
        /// </remarks>
        public static TagItemCollection GetByLastOk(bool lastOk, BootFX.Common.Data.SqlOperator lastOkOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastOk", lastOkOperator, lastOk);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where LastError is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>LastError</c>
        /// </remarks>
        public static TagItemCollection GetByLastError(string lastError)
        {
            return Br.StackFoo.TagItem.GetByLastError(lastError, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where LastError matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastError</c>
        /// </remarks>
        public static TagItemCollection GetByLastError(string lastError, BootFX.Common.Data.SqlOperator lastErrorOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastError", lastErrorOperator, lastError);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where LastError matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastError</c>
        /// </remarks>
        public static TagItemCollection GetByLastError(string lastError, BootFX.Common.Data.SqlOperator lastErrorOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastError", lastErrorOperator, lastError);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where ForceActive is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>ForceActive</c>
        /// </remarks>
        public static TagItemCollection GetByForceActive(bool forceActive)
        {
            return Br.StackFoo.TagItem.GetByForceActive(forceActive, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where ForceActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ForceActive</c>
        /// </remarks>
        public static TagItemCollection GetByForceActive(bool forceActive, BootFX.Common.Data.SqlOperator forceActiveOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("ForceActive", forceActiveOperator, forceActive);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where ForceActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ForceActive</c>
        /// </remarks>
        public static TagItemCollection GetByForceActive(bool forceActive, BootFX.Common.Data.SqlOperator forceActiveOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("ForceActive", forceActiveOperator, forceActive);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where LastUpdateUtc is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>LastUpdateUtc</c>
        /// </remarks>
        public static TagItemCollection GetByLastUpdateUtc(System.DateTime lastUpdateUtc)
        {
            return Br.StackFoo.TagItem.GetByLastUpdateUtc(lastUpdateUtc, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where LastUpdateUtc matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastUpdateUtc</c>
        /// </remarks>
        public static TagItemCollection GetByLastUpdateUtc(System.DateTime lastUpdateUtc, BootFX.Common.Data.SqlOperator lastUpdateUtcOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastUpdateUtc", lastUpdateUtcOperator, lastUpdateUtc);
            return ((TagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where LastUpdateUtc matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastUpdateUtc</c>
        /// </remarks>
        public static TagItemCollection GetByLastUpdateUtc(System.DateTime lastUpdateUtc, BootFX.Common.Data.SqlOperator lastUpdateUtcOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagItem));
            filter.Constraints.Add("LastUpdateUtc", lastUpdateUtcOperator, lastUpdateUtc);
            TagItemCollection results = ((TagItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Get all of the child 'QuestionTagItem' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>Tag</c>.  (Stub method.)
        /// </remarks>
        public QuestionTagItemCollection GetQuestionTagItemItems()
        {
            // defer...
            return TagItem.GetQuestionTagItemItems(this.TagId);
        }
        
        /// <summary>
        /// Get all of the child 'QuestionTagItem' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>Tag</c>.  (Concrete method.)
        /// </remarks>
        public static QuestionTagItemCollection GetQuestionTagItemItems(int tagId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(QuestionTagItem));
            filter.Constraints.Add("TagId", BootFX.Common.Data.SqlOperator.EqualTo, tagId);
            return ((QuestionTagItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Searches for <see cref="TagItem"/> items with the given terms.
        /// </summary>
        public static TagItemCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(TagItem), terms);
            return ((TagItemCollection)(searcher.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Returns the value in the 'Name' property.
        /// </summary>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
