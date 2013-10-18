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
    /// Defines the base entity type for 'TagSets'.
    /// </summary>
    [Serializable()]
    public abstract class TagSetBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TagSetBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected TagSetBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'TagSetId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'TagSetId' column.
        /// </remarks>
        [EntityField("TagSetId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
        public int TagSetId
        {
            get
            {
                return ((int)(this["TagSetId"]));
            }
            set
            {
                this["TagSetId"] = value;
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
        /// Gets or sets the value for 'Tags'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Tags' column.
        /// </remarks>
        [EntityField("Tags", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 256)]
        public string Tags
        {
            get
            {
                return ((string)(this["Tags"]));
            }
            set
            {
                this["Tags"] = value;
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'TagSet'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(TagSet));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'TagSet'.
        /// </summary>
        public static void SetProperties(int tagSetId, string[] propertyNames, object[] propertyValues)
        {
            TagSet entity = Br.StackFoo.TagSet.GetById(tagSetId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="TagSet"/> entities.
        /// </summary>
        public static TagSetCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(TagSet));
            return ((TagSetCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="TagSet"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagSet
        /// </bootfx>
        public static TagSet GetById(int tagSetId)
        {
            return Br.StackFoo.TagSet.GetById(tagSetId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="TagSet"/> entity where the ID matches the given specification.
        /// </summary>
        public static TagSet GetById(int tagSetId, BootFX.Common.Data.SqlOperator tagSetIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagSet));
            filter.Constraints.Add("TagSetId", tagSetIdOperator, tagSetId);
            return ((TagSet)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="TagSet"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagSet
        /// </bootfx>
        public static TagSet GetById(int tagSetId, BootFX.Common.OnNotFound onNotFound)
        {
            return Br.StackFoo.TagSet.GetById(tagSetId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="TagSet"/> entity where the ID matches the given specification.
        /// </summary>
        public static TagSet GetById(int tagSetId, BootFX.Common.Data.SqlOperator tagSetIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagSet));
            filter.Constraints.Add("TagSetId", tagSetIdOperator, tagSetId);
            TagSet results = ((TagSet)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Name is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagSet
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Name</c>
        /// </remarks>
        public static TagSetCollection GetByName(string name)
        {
            return Br.StackFoo.TagSet.GetByName(name, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Name matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Name</c>
        /// </remarks>
        public static TagSetCollection GetByName(string name, BootFX.Common.Data.SqlOperator nameOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagSet));
            filter.Constraints.Add("Name", nameOperator, name);
            return ((TagSetCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Name matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Name</c>
        /// </remarks>
        public static TagSetCollection GetByName(string name, BootFX.Common.Data.SqlOperator nameOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagSet));
            filter.Constraints.Add("Name", nameOperator, name);
            TagSetCollection results = ((TagSetCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Tags is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - TagSet
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Tags</c>
        /// </remarks>
        public static TagSetCollection GetByTags(string tags)
        {
            return Br.StackFoo.TagSet.GetByTags(tags, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Tags matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Tags</c>
        /// </remarks>
        public static TagSetCollection GetByTags(string tags, BootFX.Common.Data.SqlOperator tagsOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagSet));
            filter.Constraints.Add("Tags", tagsOperator, tags);
            return ((TagSetCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Tags matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Tags</c>
        /// </remarks>
        public static TagSetCollection GetByTags(string tags, BootFX.Common.Data.SqlOperator tagsOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(TagSet));
            filter.Constraints.Add("Tags", tagsOperator, tags);
            TagSetCollection results = ((TagSetCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Searches for <see cref="TagSet"/> items with the given terms.
        /// </summary>
        public static TagSetCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(TagSet), terms);
            return ((TagSetCollection)(searcher.ExecuteEntityCollection()));
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
