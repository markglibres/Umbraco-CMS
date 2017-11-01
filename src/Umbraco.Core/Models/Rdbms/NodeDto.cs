﻿using System;
using NPoco;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;

namespace Umbraco.Core.Models.Rdbms
{
    [TableName(TableName)]
    [PrimaryKey("id")]
    [ExplicitColumns]
    internal class NodeDto
    {
        private const string TableName = Constants.DatabaseSchema.Tables.Node;
        public const int NodeIdSeed = 1060;

        [Column("id")]
        [PrimaryKeyColumn(Name = "PK_" + TableName, IdentitySeed = NodeIdSeed)]
        public int NodeId { get; set; }

        [Column("uniqueId")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [Index(IndexTypes.UniqueNonClustered, Name = "IX_" + TableName + "_UniqueId")]
        [Constraint(Default = SystemMethods.NewGuid)]
        public Guid UniqueId { get; set; }

        [Column("parentId")]
        [ForeignKey(typeof(NodeDto))]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_ParentId")]
        public int ParentId { get; set; }

        [Column("level")]
        public short Level { get; set; }

        [Column("path")]
        [Length(150)]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_Path")]
        public string Path { get; set; }

        [Column("sortOrder")]
        public int SortOrder { get; set; }

        [Column("trashed")]
        [Constraint(Default = "0")]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_Trashed")]
        public bool Trashed { get; set; }

        [Column("nodeUser")] // fixme dbfix rename userId
        [NullSetting(NullSetting = NullSettings.Null)]
        public int? UserId { get; set; }

        [Column("text")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string Text { get; set; }

        [Column("nodeObjectType")] // fixme dbfix rename objectType
        [NullSetting(NullSetting = NullSettings.Null)]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_ObjectType")]
        public Guid? NodeObjectType { get; set; } // fixme dbfix rename ObjectType

        [Column("createDate")]
        [Constraint(Default = SystemMethods.CurrentDateTime)]
        public DateTime CreateDate { get; set; }
    }
}
