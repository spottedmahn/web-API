const ConnectionFactory = (() => {

  const stores = ['curriculo'];
  const version = 1;
  const dataBaseName = 'formCurriculo';

  var connection = null;
  var close = null;

  return class ConnectionFactory {
    constructor() {
      throw Error('Não pode ser instaciada');
    }

    static getConnection() {
      return new Promise((resolve, reject) => {
        let openRequest = window.indexedDB.open(dataBaseName, version);

        openRequest.onupgradeneeded = event => {
          ConnectionFactory._createStore(event.target.result);
        };

        openRequest.onsuccess = event => {
          if (!connection) {
            connection = event.target.result;
            close = connection.close;

            connection.close = () => {
              throw new console.error('Não é possivel fechar a conexao');
            }
          }
          resolve(connection);
        };

        openRequest.onerror = event => {
          console.log(event.target.error.name);
          reject(event.targe.error.name);
        };
      });
    }

    static _openStore(connection) {
      stores.forEach(store => {
        if (connection.objectStoreNames.contains(store))
          connection.deleteObjectStore(store);
        connection.createObjectStore(store, {autoIncrement: true});
      });
    }

    static closeConnection() {
      if (connection) {
        Reflect.apply(close, connection, []);
        connection = null;
      }
    }
  }
});
