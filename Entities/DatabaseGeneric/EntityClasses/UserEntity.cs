﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using WeeksPlanning.Entity.HelperClasses;
using WeeksPlanning.Entity.FactoryClasses;
using WeeksPlanning.Entity.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace WeeksPlanning.Entity.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'User'.<br/><br/></summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private EntityCollection<PlanEntity> _createdPlans;
		private EntityCollection<PlanEntity> _modifiedPlans;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static UserEntityStaticMetaData _staticMetaData = new UserEntityStaticMetaData();
		private static UserRelations _relationsFactory = new UserRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CreatedPlans</summary>
			public static readonly string CreatedPlans = "CreatedPlans";
			/// <summary>Member name ModifiedPlans</summary>
			public static readonly string ModifiedPlans = "ModifiedPlans";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class UserEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public UserEntityStaticMetaData()
			{
				SetEntityCoreInfo("UserEntity", InheritanceHierarchyType.None, false, (int)WeeksPlanning.Entity.EntityType.UserEntity, typeof(UserEntity), typeof(UserEntityFactory), false);
				AddNavigatorMetaData<UserEntity, EntityCollection<PlanEntity>>("CreatedPlans", a => a._createdPlans, (a, b) => a._createdPlans = b, a => a.CreatedPlans, () => new UserRelations().PlanEntityUsingCreatedByUserId, typeof(PlanEntity), (int)WeeksPlanning.Entity.EntityType.PlanEntity);
				AddNavigatorMetaData<UserEntity, EntityCollection<PlanEntity>>("ModifiedPlans", a => a._modifiedPlans, (a, b) => a._modifiedPlans = b, a => a.ModifiedPlans, () => new UserRelations().PlanEntityUsingLastModifiedByUserId, typeof(PlanEntity), (int)WeeksPlanning.Entity.EntityType.PlanEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static UserEntity()
		{
		}

		/// <summary> CTor</summary>
		public UserEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UserEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for User which data should be fetched into this User object</param>
		public UserEntity(System.Int64 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(System.Int64 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected UserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Plan' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCreatedPlans() { return CreateRelationInfoForNavigator("CreatedPlans"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Plan' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoModifiedPlans() { return CreateRelationInfoForNavigator("ModifiedPlans"); }
		
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
		/// <param name="validator">The validator object for this UserEntity</param>
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
		public static UserRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Plan' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCreatedPlans { get { return _staticMetaData.GetPrefetchPathElement("CreatedPlans", CommonEntityBase.CreateEntityCollection<PlanEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Plan' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathModifiedPlans { get { return _staticMetaData.GetPrefetchPathElement("ModifiedPlans", CommonEntityBase.CreateEntityCollection<PlanEntity>()); } }

		/// <summary>The DateCreatedUtc property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."DateCreatedUtc".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreatedUtc
		{
			get { return (System.DateTime)GetValue((int)UserFieldIndex.DateCreatedUtc, true); }
			set	{ SetValue((int)UserFieldIndex.DateCreatedUtc, value); }
		}

		/// <summary>The Email property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Email".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Email, true); }
			set	{ SetValue((int)UserFieldIndex.Email, value); }
		}

		/// <summary>The Id property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Id".<br/>Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)UserFieldIndex.Id, true); }
			set { SetValue((int)UserFieldIndex.Id, value); }		}

		/// <summary>The IsActive property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IsActive".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.IsActive, true); }
			set	{ SetValue((int)UserFieldIndex.IsActive, value); }
		}

		/// <summary>The LastLoginDate property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastLoginDate".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastLoginDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastLoginDate, false); }
			set	{ SetValue((int)UserFieldIndex.LastLoginDate, value); }
		}

		/// <summary>The LastModifiedUtc property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastModifiedUtc".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedUtc
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastModifiedUtc, false); }
			set	{ SetValue((int)UserFieldIndex.LastModifiedUtc, value); }
		}

		/// <summary>The Name property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Name".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Name, true); }
			set	{ SetValue((int)UserFieldIndex.Name, value); }
		}

		/// <summary>The Password property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Password".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Password, true); }
			set	{ SetValue((int)UserFieldIndex.Password, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'PlanEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(PlanEntity))]
		public virtual EntityCollection<PlanEntity> CreatedPlans { get { return GetOrCreateEntityCollection<PlanEntity, PlanEntityFactory>("CreatedByUser", true, false, ref _createdPlans); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'PlanEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(PlanEntity))]
		public virtual EntityCollection<PlanEntity> ModifiedPlans { get { return GetOrCreateEntityCollection<PlanEntity, PlanEntityFactory>("ModifiedByUser", true, false, ref _modifiedPlans); } }

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace WeeksPlanning.Entity
{
	public enum UserFieldIndex
	{
		///<summary>DateCreatedUtc. </summary>
		DateCreatedUtc,
		///<summary>Email. </summary>
		Email,
		///<summary>Id. </summary>
		Id,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>LastLoginDate. </summary>
		LastLoginDate,
		///<summary>LastModifiedUtc. </summary>
		LastModifiedUtc,
		///<summary>Name. </summary>
		Name,
		///<summary>Password. </summary>
		Password,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace WeeksPlanning.Entity.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: User. </summary>
	public partial class UserRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between UserEntity and PlanEntity over the 1:n relation they have, using the relation between the fields: User.Id - Plan.CreatedByUserId</summary>
		public virtual IEntityRelation PlanEntityUsingCreatedByUserId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CreatedPlans", true, new[] { UserFields.Id, PlanFields.CreatedByUserId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and PlanEntity over the 1:n relation they have, using the relation between the fields: User.Id - Plan.LastModifiedByUserId</summary>
		public virtual IEntityRelation PlanEntityUsingLastModifiedByUserId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "ModifiedPlans", true, new[] { UserFields.Id, PlanFields.LastModifiedByUserId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticUserRelations
	{
		internal static readonly IEntityRelation PlanEntityUsingCreatedByUserIdStatic = new UserRelations().PlanEntityUsingCreatedByUserId;
		internal static readonly IEntityRelation PlanEntityUsingLastModifiedByUserIdStatic = new UserRelations().PlanEntityUsingLastModifiedByUserId;

		/// <summary>CTor</summary>
		static StaticUserRelations() { }
	}
}
