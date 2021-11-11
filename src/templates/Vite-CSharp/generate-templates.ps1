$baseFolder = '.files'
$frameworks = @(
  'lit',
  'lit-ts',
  'preact',
  'preact-ts',
  'react',
  'react-ts',
  'svelte',
  'svelte-ts',
  'vanilla',
  'vanilla-ts',
  'vue',
  'vue-ts'
)

foreach ($item in $frameworks) {
  $path = Join-Path $baseFolder $item
  # Start-Process -FilePath "npm" -ArgumentList @("init", "vite@latest", "$item", "--template $item", "--overwrite") -WorkingDirectory $baseFolder
  "npm init vite@latest $item --template $item"
}
