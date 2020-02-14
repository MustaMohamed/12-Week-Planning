﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using WeeksPlanning.Entity.HelperClasses;
using WeeksPlanning.Entity.FactoryClasses;
using WeeksPlanning.Entity.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace WeeksPlanning.Entity.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'Plan'.<br/><br/></summary>
	[Serializable]
	public partial class PlanEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private UserEntity _user;
		private UserEntity _user1;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static PlanEntityStaticMetaData _staticMetaData = new PlanEntityStaticMetaData();
		private static PlanRelations _relationsFactory = new PlanRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
			/// <summary>Member name User1</summary>
			public static readonly string User1 = "User1";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class PlanEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public PlanEntityStaticMetaData()
			{
				SetEntityCoreInfo("PlanEntity", InheritanceHierarchyType.None, false, (int)WeeksPlanning.Entity.EntityType.PlanEntity, typeof(PlanEntity), typeof(PlanEntityFactory), false);
				AddNavigatorMetaData<PlanEntity, UserEntity>("User", "Plans", (a, b) => a._user = b, a => a._user, (a, b) => a.User = b, WeeksPlanning.Entity.RelationClasses.StaticPlanRelations.UserEntityUsingCreatedByUserIdStatic, ()=>new PlanRelations().UserEntityUsingCreatedByUserId, null, new int[] { (int)PlanFieldIndex.CreatedByUserId }, null, true, (int)WeeksPlanning.Entity.EntityType.UserEntity);
				AddNavigatorMetaData<PlanEntity, UserEntity>("User1", "Plans1", (a, b) => a._user1 = b, a => a._user1, (a, b) => a.User1 = b, WeeksPlanning.Entity.RelationClasses.StaticPlanRelations.UserEntityUsingLastModifiedByUserIdStatic, ()=>new PlanRelations().UserEntityUsingLastModifiedByUserId, null, new int[] { (int)PlanFieldIndex.LastModifiedByUserId }, null, true, (int)WeeksPlanning.Entity.EntityType.UserEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static PlanEntity()
		{
		}

		/// <summary> CTor</summary>
		public PlanEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PlanEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PlanEntity</param>
		public PlanEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Plan which data should be fetched into this Plan object</param>
		public PlanEntity(System.Int64 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Plan which data should be fetched into this Plan object</param>
		/// <param name="validator">The custom validator object for this PlanEntity</param>
		public PlanEntity(System.Int64 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PlanEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUser() { return CreateRelationInfoForNavigator("User"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUser1() { return CreateRelationInfoForNavigator("User1"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PlanEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static PlanRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUser { get { return _staticMetaData.GetPrefetchPathElement("User", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUser1 { get { return _staticMetaData.GetPrefetchPathElement("User1", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>The CreatedByUserId property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."CreatedByUserId".<br/>Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PlanFieldIndex.CreatedByUserId, false); }
			set	{ SetValue((int)PlanFieldIndex.CreatedByUserId, value); }
		}

		/// <summary>The DateCreatedUtc property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."DateCreatedUtc".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreatedUtc
		{
			get { return (System.DateTime)GetValue((int)PlanFieldIndex.DateCreatedUtc, true); }
			set	{ SetValue((int)PlanFieldIndex.DateCreatedUtc, value); }
		}

		/// <summary>The DurationInWeeks property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."DurationInWeeks".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 DurationInWeeks
		{
			get { return (System.Int16)GetValue((int)PlanFieldIndex.DurationInWeeks, true); }
			set	{ SetValue((int)PlanFieldIndex.DurationInWeeks, value); }
		}

		/// <summary>The Id property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."Id".<br/>Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)PlanFieldIndex.Id, true); }
			set { SetValue((int)PlanFieldIndex.Id, value); }		}

		/// <summary>The IsActive property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."IsActive".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PlanFieldIndex.IsActive, true); }
			set	{ SetValue((int)PlanFieldIndex.IsActive, value); }
		}

		/// <summary>The LastModifiedByUserId property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."LastModifiedByUserId".<br/>Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LastModifiedByUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PlanFieldIndex.LastModifiedByUserId, false); }
			set	{ SetValue((int)PlanFieldIndex.LastModifiedByUserId, value); }
		}

		/// <summary>The LastModifiedUtc property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."LastModifiedUtc".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedUtc
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PlanFieldIndex.LastModifiedUtc, false); }
			set	{ SetValue((int)PlanFieldIndex.LastModifiedUtc, value); }
		}

		/// <summary>The Name property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."Name".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)PlanFieldIndex.Name, true); }
			set	{ SetValue((int)PlanFieldIndex.Name, value); }
		}

		/// <summary>The StartingDateUtc property of the Entity Plan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Plan"."StartingDateUtc".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime StartingDateUtc
		{
			get { return (System.DateTime)GetValue((int)PlanFieldIndex.StartingDateUtc, true); }
			set	{ SetValue((int)PlanFieldIndex.StartingDateUtc, value); }
		}

		/// <summary>Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual UserEntity User
		{
			get { return _user; }
			set { SetSingleRelatedEntityNavigator(value, "User"); }
		}

		/// <summary>Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual UserEntity User1
		{
			get { return _user1; }
			set { SetSingleRelatedEntityNavigator(value, "User1"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace WeeksPlanning.Entity
{
	public enum PlanFieldIndex
	{
		///<summary>CreatedByUserId. </summary>
		CreatedByUserId,
		///<summary>DateCreatedUtc. </summary>
		DateCreatedUtc,
		///<summary>DurationInWeeks. </summary>
		DurationInWeeks,
		///<summary>Id. </summary>
		Id,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>LastModifiedByUserId. </summary>
		LastModifiedByUserId,
		///<summary>LastModifiedUtc. </summary>
		LastModifiedUtc,
		///<summary>Name. </summary>
		Name,
		///<summary>StartingDateUtc. </summary>
		StartingDateUtc,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace WeeksPlanning.Entity.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Plan. </summary>
	public partial class PlanRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between PlanEntity and UserEntity over the m:1 relation they have, using the relation between the fields: Plan.CreatedByUserId - User.Id</summary>
		public virtual IEntityRelation UserEntityUsingCreatedByUserId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "User", false, new[] { UserFields.Id, PlanFields.CreatedByUserId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PlanEntity and UserEntity over the m:1 relation they have, using the relation between the fields: Plan.LastModifiedByUserId - User.Id</summary>
		public virtual IEntityRelation UserEntityUsingLastModifiedByUserId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "User1", false, new[] { UserFields.Id, PlanFields.LastModifiedByUserId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticPlanRelations
	{
		internal static readonly IEntityRelation UserEntityUsingCreatedByUserIdStatic = new PlanRelations().UserEntityUsingCreatedByUserId;
		internal static readonly IEntityRelation UserEntityUsingLastModifiedByUserIdStatic = new PlanRelations().UserEntityUsingLastModifiedByUserId;

		/// <summary>CTor</summary>
		static StaticPlanRelations() { }
	}
}