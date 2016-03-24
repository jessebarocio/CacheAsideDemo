# Cache-Aside Demo

A simple demonstration of the cache-aside pattern using Redis cache.

## Note

If for some reason you want to clone and run this you'll need to add a `SecretSettings.config` file to the root of the CacheAsideDemo project. This keeps your Redis connection string out of source control.

    <?xml version="1.0" encoding="utf-8"?>
    <appSettings>
        <add key="RedisConnString" value="{Your Redis ConnString here}" />
    </appSettings>