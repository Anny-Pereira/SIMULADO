BULK INSERT Equipamentos
FROM 'C:\equipamentos.csv'
WITH (
	FIELDTERMINATOR = ';',
	ROWTERMINATOR  = '\n',
	FIRSTROW = 2,
	CODEPAGE = 'acp'
);

BULK INSERT Comentarios
FROM 'C:\comentarios.csv'
WITH (
	FIELDTERMINATOR = ';',
	ROWTERMINATOR  = '\n',
	FIRSTROW = 2,
	CODEPAGE = 'acp'
);

BULK INSERT Perfis
FROM 'C:\perfis.csv'
WITH (
	FIELDTERMINATOR = ';',
	ROWTERMINATOR  = '\n',
	FIRSTROW = 2,
	CODEPAGE = 'acp'
);

BULK INSERT Usuarios
FROM 'C:\usuarios.csv'
WITH (
	FIELDTERMINATOR = ';',
	ROWTERMINATOR  = '\n',
	FIRSTROW = 2,
	CODEPAGE = 'acp'
);