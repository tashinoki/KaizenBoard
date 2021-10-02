﻿// <auto-generated />
using System;
using KanbanDomain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KanbanDomain.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20211002091416_ChangeMemberMyTaskToDeleteMyTaskId")]
    partial class ChangeMemberMyTaskToDeleteMyTaskId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contract.Entity.Kanban", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("board_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("KanbanBoardId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("kanban_board_id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("Sequence")
                        .HasColumnType("int")
                        .HasColumnName("sequence");

                    b.HasKey("Id")
                        .HasName("pk_kanbans");

                    b.HasIndex("KanbanBoardId")
                        .HasDatabaseName("ix_kanbans_kanban_board_id");

                    b.ToTable("kanbans");
                });

            modelBuilder.Entity("Contract.Entity.KanbanBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_kanban_boards");

                    b.ToTable("kanban_boards");
                });

            modelBuilder.Entity("Contract.Entity.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("HandleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("handle_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("member_id");

                    b.HasKey("Id")
                        .HasName("pk_members");

                    b.ToTable("members");
                });

            modelBuilder.Entity("Contract.Entity.MyTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("KanbanId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("kanban_id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_my_tasks");

                    b.HasIndex("KanbanId")
                        .HasDatabaseName("ix_my_tasks_kanban_id");

                    b.ToTable("my_tasks");
                });

            modelBuilder.Entity("Contract.Entity.TaskTimer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("FinishedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("finished_at");

                    b.Property<bool>("IsFinised")
                        .HasColumnType("bit")
                        .HasColumnName("is_finised");

                    b.Property<Guid?>("MyTaskId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("my_task_id");

                    b.Property<DateTimeOffset>("StartedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("started_at");

                    b.HasKey("Id")
                        .HasName("pk_task_timers");

                    b.HasIndex("MyTaskId")
                        .HasDatabaseName("ix_task_timers_my_task_id");

                    b.ToTable("task_timers");
                });

            modelBuilder.Entity("KanbanBoardMember", b =>
                {
                    b.Property<Guid>("KanbanBoardsId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("kanban_boards_id");

                    b.Property<Guid>("MembersId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("members_id");

                    b.HasKey("KanbanBoardsId", "MembersId")
                        .HasName("pk_kanban_board_member");

                    b.HasIndex("MembersId")
                        .HasDatabaseName("ix_kanban_board_member_members_id");

                    b.ToTable("kanban_board_member");
                });

            modelBuilder.Entity("MemberMyTask", b =>
                {
                    b.Property<Guid>("MembersId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("members_id");

                    b.Property<Guid>("MyTasksId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("my_tasks_id");

                    b.HasKey("MembersId", "MyTasksId")
                        .HasName("pk_member_my_task");

                    b.HasIndex("MyTasksId")
                        .HasDatabaseName("ix_member_my_task_my_tasks_id");

                    b.ToTable("member_my_task");
                });

            modelBuilder.Entity("Contract.Entity.Kanban", b =>
                {
                    b.HasOne("Contract.Entity.KanbanBoard", null)
                        .WithMany("Kanbans")
                        .HasForeignKey("KanbanBoardId")
                        .HasConstraintName("fk_kanbans_kanban_boards_kanban_board_id");
                });

            modelBuilder.Entity("Contract.Entity.MyTask", b =>
                {
                    b.HasOne("Contract.Entity.Kanban", "Kanban")
                        .WithMany("Tasks")
                        .HasForeignKey("KanbanId")
                        .HasConstraintName("fk_my_tasks_kanbans_kanban_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kanban");
                });

            modelBuilder.Entity("Contract.Entity.TaskTimer", b =>
                {
                    b.HasOne("Contract.Entity.MyTask", null)
                        .WithMany("Timers")
                        .HasForeignKey("MyTaskId")
                        .HasConstraintName("fk_task_timers_my_tasks_my_task_id");
                });

            modelBuilder.Entity("KanbanBoardMember", b =>
                {
                    b.HasOne("Contract.Entity.KanbanBoard", null)
                        .WithMany()
                        .HasForeignKey("KanbanBoardsId")
                        .HasConstraintName("fk_kanban_board_member_kanban_boards_kanban_boards_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contract.Entity.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .HasConstraintName("fk_kanban_board_member_members_members_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemberMyTask", b =>
                {
                    b.HasOne("Contract.Entity.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .HasConstraintName("fk_member_my_task_members_members_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contract.Entity.MyTask", null)
                        .WithMany()
                        .HasForeignKey("MyTasksId")
                        .HasConstraintName("fk_member_my_task_my_tasks_my_tasks_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contract.Entity.Kanban", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Contract.Entity.KanbanBoard", b =>
                {
                    b.Navigation("Kanbans");
                });

            modelBuilder.Entity("Contract.Entity.MyTask", b =>
                {
                    b.Navigation("Timers");
                });
#pragma warning restore 612, 618
        }
    }
}
