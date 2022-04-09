CREATE DATABASE Tutorias
GO

USE Tutorias
GO

CREATE TABLE Usuarios(
Id_Usuario INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[User] NVARCHAR(10) NOT NULL,
[Pass] NVARCHAR(MAX) NOT NULL,
[TIPO] NUMERIC NOT NULL
);
GO

create table Alumno(
Id_Alumno INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Usuario INT NOT NULL,
Nombre NVARCHAR(50) NOT NULL,
Apellido_Pat NVARCHAR(40) NOT NULL,
Apellido_Mat NVARCHAR(40) NOT NULL,
Correo NVARCHAR(30) NULL,
Grupo NVARCHAR(6) NOT NULL,
TUTORIA BIT NOT NULL,
Visibilidad BIT NOT NULL,
CONSTRAINT fk_Usuario_Alumno FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO
CREATE TABLE AreaTutorias(
Id_Area INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Usuario INT NOT NULL,
NombreArea NVARCHAR(50) NOT NULL,
Administrador NVARCHAR(50) NOT NULL,
Visibilidad BIT NOT NULL,
CONSTRAINT fk_Usuario_Admin FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO
create table Profesor(
Id_Profesor INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Usuario INT NOT NULL,
Nombre NVARCHAR(50) NOT NULL,
Apellido_Pat NVARCHAR(50) NOT NULL,
Apellido_Mat NVARCHAR(50) NOT NULL,
Correo NVARCHAR(50) NULL,	
HorasTotales INT NOT NULL,
HorasTutoria INT NOT NULL,
Visibilidad BIT NOT NULL,
CONSTRAINT fk_Usuario_Profesor FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);
GO


create table Inscripcion(
Id_Inscripcion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Id_Profesor INT NOT NULL,
Id_Alumno INT NOT NULL,
Fecha DATE NOT NULL,
Folio INT NOT NULL,
CONSTRAINT fk_Alumno FOREIGN KEY(Id_Alumno) REFERENCES Alumno(Id_Alumno),
CONSTRAINT fk_Profesor FOREIGN KEY(Id_Profesor) REFERENCES Profesor(Id_Profesor)
);
GO

CREATE TABLE Grupos(
Id_Grupo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Grupo NVARCHAR(6) NOT NULL,
Id_Profesor INT NOT NULL,
CONSTRAINT fk_Gropos_Profesor FOREIGN KEY(Id_Profesor) REFERENCES Profesor(Id_Profesor)
)
GO

--ABGICIG6y
INSERT INTO Usuarios VALUES ('2017137462','D306F48079D83EED9AEAA8D60DD4AFE66DC786A3F0CC2AB8BC6F64F2EF603C63',2);
INSERT INTO Alumno VALUES(1, 'CINDY', 'ABAD', 'GIRON',null, '6IV11',0,0); 
--ALPIJET6p
INSERT INTO Usuarios VALUES ('2019131513','CD3E0B066A89BDD2166623A2DC9874EE10E235A64FD152852E214302B8D0238A',2);
INSERT INTO Alumno VALUES(2, 'JESUS', 'ALONSO', 'PIEDRAS',null, '6IV11',0,0); 
--AVAVDAD1x
INSERT INTO Usuarios VALUES ('2020131596','DE61E19CF4DBC51140BD1EFCCED8ACDFF55B28A14C90B13A3E8CAA4E56D1B222',2);
INSERT INTO Alumno VALUES(3, 'DAVID', 'AVILA', 'AVILA',null, '6IV11',0,0); 
--BECATAD4k
INSERT INTO Usuarios VALUES ('2020131823','3650C1A56B1253B3804B06D0A2FAE58B984A09315614AEE7AF0A11D342BE84DD',2);
INSERT INTO Alumno VALUES(4, 'TANIA', 'BECERRA', 'CAMPOS',null, '6IV11',0,0); 
--BEROANN4g
INSERT INTO Usuarios VALUES ('2019130193','762A6D09C163ED9F428BE5F43342DC7C55374137845EDDA4C8EBF5D8C7C29DDD',2);
INSERT INTO Alumno VALUES(5, 'ANGEL', 'BECERRIL', 'RODRIGUEZ',null, '6IV11',0,0); 
--BEOLALU3y
INSERT INTO Usuarios VALUES ('2020131004','063285199945ED10A6DE25127507D9DD9974A8DD3ABE47F1D4DE15B0CABE79A1',2);
INSERT INTO Alumno VALUES(6, 'ALAN', 'BERMUDEZ', 'OLAIS',null, '6IV11',0,0); 
--BUILANE0q
INSERT INTO Usuarios VALUES ('2019130122','F2859EC19A1D430F378DA325C2E3B3FB2B9452348101AE0835D686E9656DCF61',2);
INSERT INTO Alumno VALUES(7, 'ANGIE', 'BUENDIA', 'ILDEFONSO',null, '6IV11',0,0); 
--CAGOMAR2j
INSERT INTO Usuarios VALUES ('2018134941','43922B0EF619E6A6A07D58D8362D199E4ED96832FA2C59D379BB63DAAD3594BA',2);
INSERT INTO Alumno VALUES(8, 'MARLOON', 'CANTU', 'GOMEZ',null, '6IV11',0,0); 
--CAHEJOJ0u
INSERT INTO Usuarios VALUES ('2020131057','6AD7E00C6E2B7DB75ACC6F0CE12C7AA67E2B089A3FAB19C269D890056793AFE0',2);
INSERT INTO Alumno VALUES(9, 'JOSUE', 'CARBAJAL', 'HERNANDEZ',null, '6IV11',0,0); 
--CALAXIU5j
INSERT INTO Usuarios VALUES ('2019130104','8C88C6B4870572304E20A72CB62610C0F48D1529144C978AA9D0A057938470D7',2);
INSERT INTO Alumno VALUES(10, 'XIAN', 'CASTREJON', 'LAZO',null, '6IV11',0,0); 
--CHRILUY1e
INSERT INTO Usuarios VALUES ('2020130753','3904310B70D3789653F1381A84C9944BC2564CFD56C7D170D095EF048503B450',2);
INSERT INTO Alumno VALUES(11, 'LUIS', 'CHACON', 'RIVERA',null, '6IV11',0,0); 
--CRPAARV0k
INSERT INTO Usuarios VALUES ('2020131601','61AE7503F986D7645410A8046B11FA02197B6AAFD08D20890C34F1FAFD437EFB',2);
INSERT INTO Alumno VALUES(12, 'ARELY', 'CRUZ', 'PARRA',null, '6IV11',0,0); 
--DELACRN1d
INSERT INTO Usuarios VALUES ('2019130181','B8D1F895BE25375C790755731A3E5EB2F5AACBCED907690CB058E425AD321614',2);
INSERT INTO Alumno VALUES(13, 'CRUZ', 'DE', 'LA',null, '6IV11',0,0); 
--ESGRBRM2k
INSERT INTO Usuarios VALUES ('2020131247','6C4AEF07B16AA4F2E758F854C5B7A7BCB6013007B2EDE64260085B6975C7AFE6',2);
INSERT INTO Alumno VALUES(14, 'BRAYAN', 'ESPINOZA', 'GRANADOS',null, '6IV11',0,0); 
--FARODIS8q
INSERT INTO Usuarios VALUES ('2019130227','146186D6E4CB60314C9D79FADA7F9301339983EA3D11878D41F1A517D33D266E',2);
INSERT INTO Alumno VALUES(15, 'DIANA', 'FAJARDO', 'ROMAN',null, '6IV11',0,0); 
--FERAOSE7i
INSERT INTO Usuarios VALUES ('2020011272','BF0D9E7ABB5C1762D65777016BEC930B9A6C21DBE6C3EB8DB5BCD847E5E727CF',2);
INSERT INTO Alumno VALUES(16, 'OSCAR', 'FERNANDEZ', 'RAMOS',null, '6IV11',0,0); 
--GAGOIAO1g
INSERT INTO Usuarios VALUES ('2020131669','67541E8BCE6FE037A9395BE52208552CD8FF9F05E4D9CDBB81B1BBC9104C5378',2);
INSERT INTO Alumno VALUES(17, 'IAN', 'GALICIA', 'GONZALEZ',null, '6IV11',0,0); 
--GOCAROR2h
INSERT INTO Usuarios VALUES ('2019130357','AB1E13177EDA0AC8AEF3D3ACE9B027562B6AE6CF7ADF7D1F6C2ABDBDC0703BD4',2);
INSERT INTO Alumno VALUES(18, 'RODRIGO', 'GONZALEZ', 'CAMACHO',null, '6IV11',0,0); 
--GOGOMIT5l
INSERT INTO Usuarios VALUES ('2018137771','05B1C29A540BF9FF74991FC7728320C1E1ADC6616463073F4CE5998F934DBF44',2);
INSERT INTO Alumno VALUES(19, 'MIGUEL', 'GONZALEZ', 'GONZALEZ',null, '6IV11',0,0); 
--GORUARO3q
INSERT INTO Usuarios VALUES ('2020130709','7B343C33D1892EBEBD5A833DC4BB998072E29916862935C8002AB59C56753A27',2);
INSERT INTO Alumno VALUES(20, 'ARACELI', 'GONZALEZ', 'RUIZ',null, '6IV11',0,0); 
--GUSAJAT2n
INSERT INTO Usuarios VALUES ('2019131237','642C2A3EDE3FFDC1526B67C8672581687CD0A09F92EBCD347B0987488E2E4653',2);
INSERT INTO Alumno VALUES(21, 'JAHIR', 'GUERRERO', 'SANCHEZ',null, '6IV11',0,0); 
--GUACRON1i
INSERT INTO Usuarios VALUES ('2020130453','B52FF778FF498CB844D75414DF16CCB5F8581F79AFFF09A59D4F2F0A44214197',2);
INSERT INTO Alumno VALUES(22, 'ROGELIO', 'GUTIERREZ', 'ACEVEDO',null, '6IV11',0,0); 
--GUMAJOF5k
INSERT INTO Usuarios VALUES ('2019130275','A740318F201FAF8DD7579A1CB9C235D7590286FFF9FA2BBBD50FB0B06A301FA7',2);
INSERT INTO Alumno VALUES(23, 'JOSHUA', 'GUZMAN', 'MACHUCA',null, '6IV11',0,0); 
--HEGUDAU2f
INSERT INTO Usuarios VALUES ('2019130924','F57297F51479D289EF128DDAAECD350CA63A4329AB757A35A7B6D425128B9306',2);
INSERT INTO Alumno VALUES(24, 'DARIO', 'HERNANDEZ', 'GUERRERO',null, '6IV11',0,0); 
--HEMEJEV5r
INSERT INTO Usuarios VALUES ('2020130442','6149DB878C2F01E460E405F78DC71842B77CF46E59FCC4280AC91AAAB475070A',2);
INSERT INTO Alumno VALUES(25, 'JESUS', 'HERNANDEZ', 'MENDOZA',null, '6IV11',0,0); 
--HEMODIF8j
INSERT INTO Usuarios VALUES ('2019131254','43A55F00D6C6635DD5343C128ECC178CFB53B4BC210F62C4EBDD5E7475405A60',2);
INSERT INTO Alumno VALUES(26, 'DIEGO', 'HERNANDEZ', 'MORENO',null, '6IV11',0,0); 
--HERUJOS1g
INSERT INTO Usuarios VALUES ('2018136381','1FD2B683C47A1F0E250DF6FC8EBFB6E029510C9CF705C6588DFD44CF7CC68733',2);
INSERT INTO Alumno VALUES(27, 'JORGE', 'HERNANDEZ', 'RUIZ',null, '6IV11',0,0); 
--HESAJOM2l
INSERT INTO Usuarios VALUES ('2020130397','5E5353D120CCF10F1C61BDE5E50F2093A40D437CD05493C2451349040F9C6812',2);
INSERT INTO Alumno VALUES(28, 'JOSE', 'HERNANDEZ', 'SANDOVAL',null, '6IV11',0,0); 
--HEDOADC2w
INSERT INTO Usuarios VALUES ('2019131213','BD0F47FF9E95FABF186CBBE2C0869D8E22F56FFDC64CA4D5C6FB1867BEC7713E',2);
INSERT INTO Alumno VALUES(29, 'ADRIEL', 'HERRERA', 'DOMINGUEZ',null, '6IV11',0,0); 
--JAGABEW0l
INSERT INTO Usuarios VALUES ('2020131727','EEFCD60AD649DAE24C7544EC41E5871DD74A46C01A57C1BF7E120751D40348E0',2);
INSERT INTO Alumno VALUES(30, 'BEATRIZ', 'JACOBO', 'GALAN',null, '6IV11',0,0); 
--LORAJOY8u
INSERT INTO Usuarios VALUES ('2020130933','10F48EDB90A68ED565B9C30B23F7E6EA66B977FF6DA1575696F2AF5E2448E40B',2);
INSERT INTO Alumno VALUES(31, 'JOSE', 'LOPEZ', 'RAMIREZ',null, '6IV11',0,0); 
--LUGAJEL6a
INSERT INTO Usuarios VALUES ('2016130601','2012A0059459FBAE8AFABD6BC6C76375D1038042BAE3EC067807CDC46697E13C',2);
INSERT INTO Alumno VALUES(32, 'JESUS', 'LUNA', 'GARCIA',null, '6IV11',0,0); 
--MERODIV1r
INSERT INTO Usuarios VALUES ('2020131881','760E647F24B244C9EFFAE1331FDA2A14F425C68A32DA6AFECE76E62033169154',2);
INSERT INTO Alumno VALUES(33, 'DIEGO', 'MENDOZA', 'RODRIGUEZ',null, '6IV11',0,0); 
--MOHEMIH8d
INSERT INTO Usuarios VALUES ('2019130557','4279DBD36D2F46D62A9D2FCBE5A9E05511E008D43DC37D28E763E9D1D9E5B67B',2);
INSERT INTO Alumno VALUES(34, 'MIGUEL', 'MORALES', 'HERRERA',null, '6IV11',0,0); 
--OLHEJOW6w
INSERT INTO Usuarios VALUES ('2020131579','FF9073FFA80D912A25510C7E85E761AEE4E39D45FC755F2AFF9FE49CE8E8B792',2);
INSERT INTO Alumno VALUES(35, 'JOSE', 'OLVERA', 'HERNANDEZ',null, '6IV11',0,0); 
--PESAOSB7p
INSERT INTO Usuarios VALUES ('2020131441','9390592A6B01C86250C8378C44DC06FDC2ABDB21A7CD745A8DA2F5378758B804',2);
INSERT INTO Alumno VALUES(36, 'OSCAR', 'PEREA', 'SAAVEDRA',null, '6IV11',0,0); 
--ROGODAO4o
INSERT INTO Usuarios VALUES ('2020131987','ADA95A49D5EE254AC293A5E38570FA7C540886F7FE797CFB111B66B6C51ECB42',2);
INSERT INTO Alumno VALUES(37, 'DANIELA', 'ROCHA', 'GONZALEZ',null, '6IV11',0,0); 
--RUMAGEB7e
INSERT INTO Usuarios VALUES ('2020131598','A18FFC4B54EFB292BF8A16B425B4F10F279E5413CD0A0CB59B2563652581CE49',2);
INSERT INTO Alumno VALUES(38, 'GERARDO', 'RUIZ', 'MACIAS',null, '6IV11',0,0); 
--RUSIULK2c
INSERT INTO Usuarios VALUES ('2017138131','C9B658D476BB1DD10EB537727CCF8A0973E64AE2C3B39C99E970C815691300AD',2);
INSERT INTO Alumno VALUES(39, 'ULISES', 'RUIZ', 'SILVA',null, '6IV11',0,0); 
--SALOALC3w
INSERT INTO Usuarios VALUES ('2019131108','7BD5BEDA37B0A23803DD984FF944D255E995C8920F2C13CB223D6959729D9F71',2);
INSERT INTO Alumno VALUES(40, 'ALFREDO', 'SANCHEZ', 'LOPEZ',null, '6IV11',0,0); 
--TAHEBEK2n
INSERT INTO Usuarios VALUES ('2020130064','E78DD6EDA755417870C4BE7930B79B9FE9F702397AF6FF4B61B5DBBB56C20A80',2);
INSERT INTO Alumno VALUES(41, 'BELINDA', 'TAPIA', 'HERNANDEZ',null, '6IV11',0,0); 
--ZAVAKEX7h
INSERT INTO Usuarios VALUES ('2020130138','06A8119EB759A54D89B7B402AE037EBD98B8705952BFD875B412D5B170EAFBCA',2);
INSERT INTO Alumno VALUES(42, 'KEVIN', 'ZAMPERIO', 'VARGAS',null, '6IV11',0,0); 
--GUMOJEJ3x
INSERT INTO Usuarios VALUES ('7179941374','73272A907DAE3856821EAACE016B71E4B96BE64819DEF7DE706E422686E6F4DD',1);
INSERT INTO Profesor VALUES(43, 'JESUS', 'GUTIERREZ', 'MORAN',null,'24', '4',1); 
--LURELUT5k
INSERT INTO Usuarios VALUES ('3555220501','A7214532835A082A23695D9BF580653F699504DC6ECC74BB3922B22CC691DCA7',1);
INSERT INTO Profesor VALUES(44, 'LUIS', 'LUNA', 'REYES',null,'24', '5',1); 
--CASACEO4o
INSERT INTO Usuarios VALUES ('1456150533','5ED138CC783C8A1DB0EC97C37434801817E431AE5A0DF4E46F89559A3092930B',1);
INSERT INTO Profesor VALUES(45, 'CESAR', 'CASILLAS', 'SAGAL',null,'24', '6',1); 
--OCHEBLH2n
INSERT INTO Usuarios VALUES ('8899392942','EA6D7CFFBB8AEB68CABBF13B072DAB4788358C4EDF88C74DA63CA5F7493AEFB3',1);
INSERT INTO Profesor VALUES(46, 'BLANCA', 'OCHOA', 'HENESTROZA',null,'24', '7',1); 
--VILEADC5b
INSERT INTO Usuarios VALUES ('4634993972','C30D2948464FDBBE0E38C1BA76E755C9EF17C840E551AB6C6FE8A9BE2D31EC45',1);
INSERT INTO Profesor VALUES(47, 'ADRIAN', 'VILLALBA', 'LEMUS',null,'24', '8',1); 
--BRSACAT6u
INSERT INTO Usuarios VALUES ('9091665250','EBE4E041F48431B79A5E4A473339C36E00C90DFF130F0B33C985805575BFCDD8',1);
INSERT INTO Profesor VALUES(48, 'CARLOS', 'BRISE�O', 'SAQUEDO',null,'24', '10',1); 
--CAGUALO8x
INSERT INTO Usuarios VALUES ('6073169703','EFCF4FBCEF6DA9E2B4B7BB5F9A8ACDA46D567DC45C8C4BB7D914C074342092BB',1);
INSERT INTO Profesor VALUES(49, 'ALFREDO', 'CAMPOS', 'GUERRERO',null,'24', '3',1); 
--MASAFEL6w
INSERT INTO Usuarios VALUES ('2751782816','AC500C066AD4A7129BF6B6081A9C3129B8530F3E28936ECABF768E6B68C04FC3',1);
INSERT INTO Profesor VALUES(50, 'FERNANDO', 'MARTINEZ', 'SANCHEZ',null,'24', '12',1); 

SELECT * FROM Alumno

SELECT A.Id_Alumno, A.Nombre, A.Apellido_Pat, A.Apellido_Mat, A.Grupo, U.[User],U.[Pass]
FROM Usuarios as U
INNER JOIN Alumno as A
ON U.Id_Usuario = A.Id_Usuario;

