﻿// <auto-generated />
using System;
using HungryHelper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HungryHelper.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220512224941_NewColumns")]
    partial class NewColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HungryHelper.Data.Entities.FavoritedRecipesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RecipeEntityRecipeId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeEntityRecipeId");

                    b.ToTable("FavoritedRecipes");
                });

            modelBuilder.Entity("HungryHelper.Data.Entities.IngredientEntity", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("HungryHelper.Data.Entities.RecipeEntity", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Directions")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("HungryHelper.Data.Entities.ShoppingListEntity", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"), 1L, 1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ListId");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("HungryHelper.Data.Entities.UserProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CookingExperienceLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<string>("FavoriteFood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("IngredientEntityRecipeEntity", b =>
                {
                    b.Property<int>("ListOfIngredientsIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("ListOfRecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("ListOfIngredientsIngredientId", "ListOfRecipesRecipeId");

                    b.HasIndex("ListOfRecipesRecipeId");

                    b.ToTable("IngredientEntityRecipeEntity");
                });

            modelBuilder.Entity("HungryHelper.Data.Entities.FavoritedRecipesEntity", b =>
                {
                    b.HasOne("HungryHelper.Data.Entities.RecipeEntity", null)
                        .WithMany("ListOfFavorites")
                        .HasForeignKey("RecipeEntityRecipeId");
                });

            modelBuilder.Entity("IngredientEntityRecipeEntity", b =>
                {
                    b.HasOne("HungryHelper.Data.Entities.IngredientEntity", null)
                        .WithMany()
                        .HasForeignKey("ListOfIngredientsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HungryHelper.Data.Entities.RecipeEntity", null)
                        .WithMany()
                        .HasForeignKey("ListOfRecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HungryHelper.Data.Entities.RecipeEntity", b =>
                {
                    b.Navigation("ListOfFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
