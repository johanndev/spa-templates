import { defineConfig } from 'vite'
import solidPlugin from 'vite-plugin-solid'
//#if (RequiresHttps)
import { readFileSync } from 'fs'
import { certFilePath, keyFilePath } from './aspnetcore-https'
//#endif

export default defineConfig({
  plugins: [solidPlugin()],
  build: {
    target: 'esnext',
    polyfillDynamicImport: false,
  },
  server: {
    //#if (RequiresHttps)
    https: {
      key: readFileSync(keyFilePath),
      cert: readFileSync(certFilePath)
    },
    //#endif
    port: 5002,
    strictPort: true,
    proxy: {
      '/api': {
        //#if (RequiresHttps)
        target: 'https://localhost:5001/',
        //#else
        target: 'http://localhost:5000/',
        //#endif
        secure: false,
        changeOrigin: true
      }
    }
  }
});
