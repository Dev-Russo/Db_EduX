using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduX_API.Migrations
{
    public partial class Concluído : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoTurma_Turma_IdTurma",
                table: "AlunoTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Objetivo_Categoria_IdCategoria",
                table: "Objetivo");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjetivoAluno_Turma_IdTurma",
                table: "ObjetivoAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Turma_IdTurma",
                table: "ProfessorTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Curso_IdCurso",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turma",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objetivo",
                table: "Objetivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "IdTurma",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "IdObjetivo",
                table: "Objetivo");

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Categoria");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Turma",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Objetivo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Curso",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Categoria",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turma",
                table: "Turma",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objetivo",
                table: "Objetivo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoTurma_Turma_IdTurma",
                table: "AlunoTurma",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objetivo_Categoria_IdCategoria",
                table: "Objetivo",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjetivoAluno_Turma_IdTurma",
                table: "ObjetivoAluno",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Turma_IdTurma",
                table: "ProfessorTurma",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Curso_IdCurso",
                table: "Turma",
                column: "IdCurso",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoTurma_Turma_IdTurma",
                table: "AlunoTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Objetivo_Categoria_IdCategoria",
                table: "Objetivo");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjetivoAluno_Turma_IdTurma",
                table: "ObjetivoAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Turma_IdTurma",
                table: "ProfessorTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Curso_IdCurso",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turma",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objetivo",
                table: "Objetivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Objetivo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categoria");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTurma",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdObjetivo",
                table: "Objetivo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdCurso",
                table: "Curso",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdCategoria",
                table: "Categoria",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turma",
                table: "Turma",
                column: "IdTurma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objetivo",
                table: "Objetivo",
                column: "IdObjetivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "IdCurso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoTurma_Turma_IdTurma",
                table: "AlunoTurma",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "IdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objetivo_Categoria_IdCategoria",
                table: "Objetivo",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjetivoAluno_Turma_IdTurma",
                table: "ObjetivoAluno",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "IdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Turma_IdTurma",
                table: "ProfessorTurma",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "IdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Curso_IdCurso",
                table: "Turma",
                column: "IdCurso",
                principalTable: "Curso",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
