/*
 * Theory of Versioining
 * 
 * Through versioning we can have : Backward compatibility for existing clients.
 * 
                                    Seamless updates for new features or breaking changes.

                                    Coexistence of multiple versions of the same functionality.
 * Versioning Approaches :
 *                          1st: URL Path versioning (/v1/product   /v2/product) 
 *                                  each template is mapped to a differtnt controler
 *                                  
 *                          2nd: Query String Versioning (?version=1 ...)
 *                                  Use a filter or middleware to inspect the query string and route the request to the appropriate version.
 *                                  
 *                          3rd: Custom Header Versioning: 
 *                                                              GET /products HTTP/1.1
 *                                                               X-API-Version: 1
 *                                                               Middleware or a custom handler checks the header and routes requests accordingly.
 *                          4th: Content Navigation:
 *                                                          Use the Accept header to specify the version.
 *                                                          GET /products HTTP/1.1
 *                                                          Accept: application/json;version=1.0


 
 */


namespace Backend1.Versioning
{
    public class Versonisng
    {
    }
}