import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import eslint from "vite-plugin-eslint";
import { readFileSync } from "fs";
import { certFilePath, keyFilePath } from "./aspnetcore-https";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), eslint()],
  server: {
    https: {
      key: readFileSync(keyFilePath),
      cert: readFileSync(certFilePath),
    },
    port: 5002,
    strictPort: true,
    proxy: {
      "/api": {
        target: "https://localhost:5001/",
        changeOrigin: true,
        secure: true,
      },
    },
  },
});
