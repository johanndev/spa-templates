import { defineConfig } from 'vite'
import preact from '@preact/preset-vite'
//#if (RequiresHttps)
import { readFileSync } from 'fs'
import { certFilePath, keyFilePath } from './aspnetcore-https'
//#endif

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [preact()],
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
})
