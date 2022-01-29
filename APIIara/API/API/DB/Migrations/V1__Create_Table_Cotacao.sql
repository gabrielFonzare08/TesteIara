CREATE TABLE IF NOT EXISTS cotacao(
	id BIGINT(20)NOT NULL auto_increment,
	cnpj_comprador VARCHAR(25) NOT NULL,
	cnpj_fornecedor VARCHAR(25) NOT NULL,
	numero_cotacao VARCHAR(25) NOT NULL,
	data_cotacao datetime NOT NULL,
	data_entrega_cotacao datetime NOT NULL,
	cep VARCHAR(12) NOT NULL,
	logradouro VARCHAR(255) ,
	complemento VARCHAR(255) ,
	bairro VARCHAR(100),
	cidade VARCHAR(120),
	uf VARCHAR(2) ,
	observacao VARCHAR(255),
	PRIMARY KEY(id)
)
