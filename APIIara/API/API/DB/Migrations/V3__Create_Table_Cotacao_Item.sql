CREATE TABLE IF NOT EXISTS Cotacao_Item(
	id BIGINT(20) NOT NULL AUTO_INCREMENT,
	descricao VARCHAR(255) NOT NULL,
	numero_item BigInt(12) NOT NULL,
	preco Decimal(18,5),
	quantidade Decimal(18,5) NOT NULL,
	marca VARCHAR(60),
	unidade VARCHAR(60),
	cotacao BIGINT(20),
	PRIMARY KEY (id)/*,
	FOREIGN KEY FK_COTACAOID(cotacaoid) REFERENCES cotacao(id)*/
)