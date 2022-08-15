CREATE database BDLogin;
Use BDLogin;

Create table TbUsuario(
UsuarioID int primary key auto_increment,
UserNome varchar(100) not null unique,
Login  varchar(0) not null unique,
Senha  varchar(100) not null
);
