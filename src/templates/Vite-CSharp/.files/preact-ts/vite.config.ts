import { defineConfig } from 'vite'
import preact from '@preact/preset-vite'
import { readFileSync } from 'fs'
import { certFilePath, keyFilePath } from './aspnetcore-https'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [preact()],
  server: {
    https: {
      key: readFileSync(keyFilePath),
      cert: readFileSync(certFilePath)
    },
    port: 5002,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:5001/',
        changeOrigin: true,
        secure: true
      }
    }
  }
})
