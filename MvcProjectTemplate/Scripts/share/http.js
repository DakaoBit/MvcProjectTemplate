/**
 *  Call JQuery Ajax
 * @param {any} parameters
 */
function CallJQAjax(parameters) {
          var { url, type, data } = parameters;

          return new Promise((resolve, reject) => {
                    $.ajax({
                              url: url,
                              type: type,
                              dataType: 'json',
                              data: data,
                              success: function (Response) {
                                        return resolve(Response);
                              }
                    });
          });
}

/**
 * HttpRequest
 * @param {any} url
 * @param {any} method
 */
function HttpRequest(url, method = 'post') {
          var paremeters = GetAllInputValue();
          if (method == 'post') {
                    const result = HttpPost(url, paremeters);
                    return result;
          } else {
                    const result = HttpGet(url, paremeters);
                    return result;
          }
}

/**
 * Http Post
 * @param {any} url
 * @param {any} data
 */
async function HttpPost(url, data) {
          return new Promise((resolve, reject) => {
                    const options = {
                              body: JSON.stringify(data),
                              headers: {
                                        'content-type': 'application/json'
                              },
                              method: 'POST',
                    }
                    fetch(url, options).then(function (response) {
                              return response.json();
                    }).then(function (jsonString) {
                              resolve(jsonString);
                    });
          });
}



/**
 * Http Get
 * @param {any} url
 * @param {any} data
 */
async function HttpGet(url, data) {
          return new Promise((resolve, reject) => {
                    let urlContent = new URL(url);
                    if (data != null) {
                              Object.keys(data).forEach(key => urlContent.searchParams.append(key, params[key]))
                    }

                    fetch(urlContent).then(function (response) {
                              return response.json();
                    }).then(function (jsonString) {
                              resolve(jsonString);
                    });
          });
}
