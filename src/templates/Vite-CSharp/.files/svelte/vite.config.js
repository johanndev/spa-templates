import { defineConfig } from 'vite'
import { svelte } from '@sveltejs/vite-plugin-svelte'
//#if (RequiresHttps)
import { readFileSync } from 'fs'
import { certFilePath, keyFilePath } from './aspnetcore-https.js'
//#endif

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [svelte()],
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
