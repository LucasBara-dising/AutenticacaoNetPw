CREATE database BDLogin;
Use BDLogin;

Create table TbUsuario(
UsuarioID int primary key auto_increment,
UserNome varchar(100) not null unique,
Login  varchar(50) not null unique,
Senha  varchar(100) not null
);

Delimiter $$
create procedure InsertUsu(UserNome varchar(100), Login varchar(50), Senha varchar(100))
begin
insert into TbUsuario(UserNome, Login, Senha)
			values(UserNome, Login, Senha);
end
$$

Delimiter $$
create procedure SelectUser(vUserNome varchar(100))
begin
Select * from TbUsuario where UserNome= vUserNome;
end
$$

Delimiter $$
create procedure SelectLogin(vLogin varchar(50))
begin
Select * from TbUsuario where Login= vLogin;
end
$$

Delimiter $$
create procedure UpdateSenha(vSenha varchar(100), vUsuarioID int)
begin
Update TbUsuario set senha=vSenha where UsuarioID=vUsuarioID;
end
$$

call InsertUsu("Luiz", "Lioz0", "123");
call UpdateSenha("1234", 1);

