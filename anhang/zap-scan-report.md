# ZAP Scanning Report


## Summary of Alerts

| Risk Level | Number of Alerts |
| --- | --- |
| High | 0 |
| Medium | 0 |
| Low | 2 |
| Informational | 2 |




## Alerts

| Name | Risk Level | Number of Instances |
| --- | --- | --- |
| Unexpected Content-Type was returned | Low | 2 |
| X-Content-Type-Options Header Missing | Low | 1 |
| A Client Error response code was returned by the server | Informational | 64 |
| Storable and Cacheable Content | Informational | 1 |




## Alert Detail



### [ Unexpected Content-Type was returned ](https://www.zaproxy.org/docs/alerts/100001/)



##### Low (High)

### Description

A Content-Type of text/html was returned by the server.
This is not one of the types expected to be returned by an API.
Raised by the 'Alert on Unexpected Content Types' script

* URL: http://localhost:5164/swagger/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `text/html`
* URL: http://localhost:5164/swagger/index.html
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `text/html`

Instances: 2

### Solution



### Reference




#### Source ID: 4

### [ X-Content-Type-Options Header Missing ](https://www.zaproxy.org/docs/alerts/10021/)



##### Low (Medium)

### Description

The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.

* URL: http://localhost:5164/swagger/v1/swagger.json
  * Method: `GET`
  * Parameter: `X-Content-Type-Options`
  * Attack: ``
  * Evidence: ``

Instances: 1

### Solution

Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.
If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.

### Reference


* [ http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx ](http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx)
* [ https://owasp.org/www-community/Security_Headers ](https://owasp.org/www-community/Security_Headers)


#### CWE Id: [ 693 ](https://cwe.mitre.org/data/definitions/693.html)


#### WASC Id: 15

#### Source ID: 3

### [ A Client Error response code was returned by the server ](https://www.zaproxy.org/docs/alerts/100000/)



##### Informational (High)

### Description

A response code of 404 was returned by the server.
This may indicate that the application is failing to handle unexpected input correctly.
Raised by the 'Alert on HTTP Response Code Error' script

* URL: http://localhost:5164
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/._darcs
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.bzr
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.DS_Store
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.env
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.git/config
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.hg
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.htaccess
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.idea/WebServers.xml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.php_cs.cache
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.ssh/id_dsa
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.ssh/id_rsa
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.svn/entries
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/.svn/wc.db
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164//_framework/blazor.boot.json
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/5084962148894571747
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/_wpeprivate/config.json
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/adminer.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/app/etc/local.xml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/BitKeeper
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/CHANGELOG.txt
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/composer.json
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/composer.lock
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/config/database.yml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/config/databases.yml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/core
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/CVS/root
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/DEADJOE
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/elmah.axd
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/filezilla.xml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/i.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/id_dsa
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/id_rsa
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/info.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/key.pem
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/latest/meta-data/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/lfm.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/myserver.key
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/phpinfo.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/privatekey.key
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/server-info
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/server-status
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/server.key
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/sftp-config.json
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/sitemanager.xml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/sites/default/files/.ht.sqlite
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/sites/default/private/files/backup_migrate/scheduled/test.txt
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/.env
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/.htaccess
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/5964500073314641962
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/trace.axd
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/v1
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/v1/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/v1/.env
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/v1/.htaccess
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/v1/4493590587158565418
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/swagger/v1/trace.axd
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/test.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/trace.axd
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/vb_test.php
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/vim_settings.xml
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/winscp.ini
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`
* URL: http://localhost:5164/WS_FTP.ini
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 404`

Instances: 64

### Solution



### Reference



#### CWE Id: [ 388 ](https://cwe.mitre.org/data/definitions/388.html)


#### WASC Id: 20

#### Source ID: 4

### [ Storable and Cacheable Content ](https://www.zaproxy.org/docs/alerts/10049/)



##### Informational (Medium)

### Description

The response contents are storable by caching components such as proxy servers, and may be retrieved directly from the cache, rather than from the origin server by the caching servers, in response to similar requests from other users.  If the response data is sensitive, personal or user-specific, this may result in sensitive information being leaked. In some cases, this may even result in a user gaining complete control of the session of another user, depending on the configuration of the caching components in use in their environment. This is primarily an issue where "shared" caching servers such as "proxy" caches are configured on the local network. This configuration is typically found in corporate or educational environments, for instance.

* URL: http://localhost:5164/swagger/v1/swagger.json
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: ``

Instances: 1

### Solution

Validate that the response does not contain sensitive, personal or user-specific information.  If it does, consider the use of the following HTTP response headers, to limit, or prevent the content being stored and retrieved from the cache by another user:
Cache-Control: no-cache, no-store, must-revalidate, private
Pragma: no-cache
Expires: 0
This configuration directs both HTTP 1.0 and HTTP 1.1 compliant caching servers to not store the response, and to not retrieve the response (without validation) from the cache, in response to a similar request. 

### Reference


* [ https://tools.ietf.org/html/rfc7234 ](https://tools.ietf.org/html/rfc7234)
* [ https://tools.ietf.org/html/rfc7231 ](https://tools.ietf.org/html/rfc7231)
* [ http://www.w3.org/Protocols/rfc2616/rfc2616-sec13.html (obsoleted by rfc7234) ](http://www.w3.org/Protocols/rfc2616/rfc2616-sec13.html (obsoleted by rfc7234))


#### CWE Id: [ 524 ](https://cwe.mitre.org/data/definitions/524.html)


#### WASC Id: 13

#### Source ID: 3


