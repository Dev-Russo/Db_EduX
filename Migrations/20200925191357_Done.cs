using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduX_API.Migrations
{
    public partial class Done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoTurma_Usuario_IdUsuario",
                table: "AlunoTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtida_Usuario_IdUsuario",
                table: "Curtida");

            migrationBuilder.DropForeignKey(
                name: "FK_Dica_Usuario_IdUsuario",
                table: "Dica");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjetivoAluno_Objetivo_IdObjetivo",
                table: "ObjetivoAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Usuario_IdUsuario",
                table: "ProfessorTurma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorTurma",
                table: "ProfessorTurma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjetivoAluno",
                table: "ObjetivoAluno");

            migrationBuilder.DropIndex(
                name: "IX_ObjetivoAluno_IdObjetivo",
                table: "ObjetivoAluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoTurma",
                table: "AlunoTurma");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdProfessorTurma",
                table: "ProfessorTurma");

            migrationBuilder.DropColumn(
                name: "IdObjetivoAluno",
                table: "ObjetivoAluno");

            migrationBuilder.DropColumn(
                name: "IdObjetivo",
                table: "ObjetivoAluno");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Instituicao");

            migrationBuilder.DropColumn(
                name: "IdAlunoTurma",
                table: "AlunoTurma");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Usuario",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProfessorTurma",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ObjetivoAluno",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Instituicao",
                nullable: false,
                defaultValue: "Logradouro");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AlunoTurma",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorTurma",
                table: "ProfessorTurma",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjetivoAluno",
                table: "ObjetivoAluno",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoTurma",
                table: "AlunoTurma",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoAluno_IdAlunoTurma",
                table: "ObjetivoAluno",
                column: "IdAlunoTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoTurma_Usuario_IdUsuario",
                table: "AlunoTurma",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtida_Usuario_IdUsuario",
                table: "Curtida",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dica_Usuario_IdUsuario",
                table: "Dica",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjetivoAluno_AlunoTurma_IdAlunoTurma",
                table: "ObjetivoAluno",
                column: "IdAlunoTurma",
                principalTable: "AlunoTurma",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Usuario_IdUsuario",
                table: "ProfessorTurma",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoTurma_Usuario_IdUsuario",
                table: "AlunoTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtida_Usuario_IdUsuario",
                table: "Curtida");

            migrationBuilder.DropForeignKey(
                name: "FK_Dica_Usuario_IdUsuario",
                table: "Dica");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjetivoAluno_AlunoTurma_IdAlunoTurma",
                table: "ObjetivoAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Usuario_IdUsuario",
                table: "ProfessorTurma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorTurma",
                table: "ProfessorTurma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjetivoAluno",
                table: "ObjetivoAluno");

            migrationBuilder.DropIndex(
                name: "IX_ObjetivoAluno_IdAlunoTurma",
                table: "ObjetivoAluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoTurma",
                table: "AlunoTurma");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfessorTurma");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ObjetivoAluno");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Instituicao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AlunoTurma");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProfessorTurma",
                table: "ProfessorTurma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdObjetivoAluno",
                table: "ObjetivoAluno",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdObjetivo",
                table: "ObjetivoAluno",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Instituicao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdAlunoTurma",
                table: "AlunoTurma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorTurma",
                table: "ProfessorTurma",
                column: "IdProfessorTurma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjetivoAluno",
                table: "ObjetivoAluno",
                column: "IdObjetivoAluno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoTurma",
                table: "AlunoTurma",
                column: "IdAlunoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoAluno_IdObjetivo",
                table: "ObjetivoAluno",
                column: "IdObjetivo");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoTurma_Usuario_IdUsuario",
                table: "AlunoTurma",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtida_Usuario_IdUsuario",
                table: "Curtida",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dica_Usuario_IdUsuario",
                table: "Dica",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjetivoAluno_Objetivo_IdObjetivo",
                table: "ObjetivoAluno",
                column: "IdObjetivo",
                principalTable: "Objetivo",
                principalColumn: "IdObjetivo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Usuario_IdUsuario",
                table: "ProfessorTurma",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
