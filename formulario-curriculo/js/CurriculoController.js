class CurriculoController {

  constructor() {
    let $ = document.querySelector.bind(document);
    this._nome = $('#nome');
    this._email = $('#email');
    this._phone = $('#phone');
    this._pais = $('#pais');
    this._estado = $('#estado');
    this._cidade = $('#cidade');
    this._file = $('#file');
  }

  logAll(event) {
    event.preventDefault();
    console.log(`
      Nome: ${this._nome}
      Email: ${this._email}
      Phone: ${this._phone}
      Pais: ${this._pais}
      Estado: ${this._estado}
      Cidade: ${this._cidade}
      File: ${this._file}
    `);
  }
}
