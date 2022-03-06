
var httpservice = {
    namespace: '/api',

    /**
     * Get data from the server 
     * @param {string} apiEndpoint
     * @param {Object} objToPush
     * @param {Function} success
     * @param {Function} error
     */
    get: function (apiEndpoint, objToPush, success, error) {      
        $.ajax({
            type: "GET",
            url: `${this.namespace}/${apiEndpoint}`,
            dataType: 'json',
            data: objToPush,
           // async: isasync,
            success: function (data) {
                if (success)
                    success(data);
            },
            error: function (data) {
                if (error)
                    error(data);
            }
        });
    },
    /**
     * Post a content to backend server (Object creation)
     * @param {string} apiEndpoint
     * @param {Object} objToPush
     * @param {Function} success
     * @param {Function} error
     */
    post: function (apiEndpoint, objToPush, success, error) {
        $.ajax({
            type: "POST",
            url: `${this.namespace}/${apiEndpoint}`,
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(objToPush),
            success: function (data) {
                if (success)
                    success(data);
            },
            error: function (data) {
                if (error)
                    error(data);
            }
        });
    },
    /**
     * Put a content to server. entity Update
     * @param {string} apiEndpoint
     * @param {Object} objToPush
     * @param {Function} success
     * @param {Function} error
     */
    put: function (apiEndpoint, objToPush, success, error) {
        $.ajax({
            type: "PUT",
            url: `${this.namespace}/${apiEndpoint}`,
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(objToPush),
            success: function (data) {
                if (success)
                    success(data);
            },
            error: function (data) {
                if (error)
                    error(data);
            }
        });
    },
    /**
     * Delete entity
     * @param {string} apiEndpoint
     * @param {Function} success
     * @param {Function} error
     */
    delete: function (apiEndpoint, success, error) {
        $.ajax({
            type: "DELETE",
            url: `${this.namespace}/${apiEndpoint}`,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (success)
                    success(data);
            },
            error: function (data) {
                if (error)
                    error(data);
            }
        });
    }  
};
