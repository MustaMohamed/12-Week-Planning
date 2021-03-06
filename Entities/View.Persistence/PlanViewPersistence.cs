﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace View.Persistence
{
	/// <summary>Static class for (extension) methods for fetching and projecting instances of View.DtoClasses.PlanView from the entity model.</summary>
	public static partial class PlanViewPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<WeeksPlanning.Entity.EntityClasses.PlanEntity, View.DtoClasses.PlanView>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<WeeksPlanning.Entity.EntityClasses.PlanEntity, View.DtoClasses.PlanView> _compiledProjector = CreateProjectionFunc().Compile();
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static PlanViewPersistence() { }
	
		/// <summary>Extension method which produces a projection to View.DtoClasses.PlanView which instances are projected from the 
		/// results of the specified baseQuery, which returns WeeksPlanning.Entity.EntityClasses.PlanEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve View.DtoClasses.PlanView instances</returns>
		public static IQueryable<View.DtoClasses.PlanView> ProjectToPlanView(this IQueryable<WeeksPlanning.Entity.EntityClasses.PlanEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}
		
		/// <summary>Extension method which produces a projection to View.DtoClasses.PlanView which instances are projected from the
		/// WeeksPlanning.Entity.EntityClasses.PlanEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>WeeksPlanning.Entity.EntityClasses.PlanEntity instance created from the specified entity instance</returns>
		public static View.DtoClasses.PlanView ProjectToPlanView(this WeeksPlanning.Entity.EntityClasses.PlanEntity entity)
		{
			return _compiledProjector(entity);
		}
		
		private static System.Linq.Expressions.Expression<Func<WeeksPlanning.Entity.EntityClasses.PlanEntity, View.DtoClasses.PlanView>> CreateProjectionFunc()
		{
			return p__0 => new View.DtoClasses.PlanView()
			{
				CreatedByUser = new View.DtoClasses.PlanViewTypes.CreatedByUser()
				{
					DateCreatedUtc = p__0.CreatedByUser.DateCreatedUtc,
					Email = p__0.CreatedByUser.Email,
					Id = p__0.CreatedByUser.Id,
					IsActive = p__0.CreatedByUser.IsActive,
					LastLoginDate = p__0.CreatedByUser.LastLoginDate,
					LastModifiedUtc = p__0.CreatedByUser.LastModifiedUtc,
					Name = p__0.CreatedByUser.Name,
					Password = p__0.CreatedByUser.Password,
				},
				CreatedByUserId = p__0.CreatedByUserId,
				DateCreatedUtc = p__0.DateCreatedUtc,
				DurationInWeeks = p__0.DurationInWeeks,
				Id = p__0.Id,
				IsActive = p__0.IsActive,
				LastModifiedByUserId = p__0.LastModifiedByUserId,
				LastModifiedUtc = p__0.LastModifiedUtc,
				ModifiedByUser = new View.DtoClasses.PlanViewTypes.ModifiedByUser()
				{
					DateCreatedUtc = p__0.ModifiedByUser.DateCreatedUtc,
					Email = p__0.ModifiedByUser.Email,
					Id = p__0.ModifiedByUser.Id,
					IsActive = p__0.ModifiedByUser.IsActive,
					LastLoginDate = p__0.ModifiedByUser.LastLoginDate,
					LastModifiedUtc = p__0.ModifiedByUser.LastModifiedUtc,
					Name = p__0.ModifiedByUser.Name,
					Password = p__0.ModifiedByUser.Password,
				},
				Name = p__0.Name,
				StartingDateUtc = p__0.StartingDateUtc,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_PlanView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
		}
	}
}

