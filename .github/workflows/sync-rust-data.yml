# .github/workflows/run-rust-plugin.yml
name: Run Rust Server Plugin

on:
  workflow_dispatch:
  schedule:
    - cron: '0 */6 * * *'  # run every 6 hours (UTC)

jobs:
  run-plugin:
    runs-on: ubuntu-latest
    timeout-minutes: 360  # up to 6 hours

    # declare where to install the server (inside workspace)
    env:
      RUST_SERVER_DIR: ${{ github.workspace }}/rust_server

    steps:
      - name: Checkout repository
        uses: actions/checkout@v3

      - name: Download and make installer executable
        run: |
          # Download installer that sets up Rust server, Oxide and plugin
          curl -sL https://raw.githubusercontent.com/publicrust/rust-server-setup/main/install_rust_server.sh \
            -o install_rust_server.sh
          chmod +x install_rust_server.sh

      - name: Install Rust server into workspace
        run: |
          # Installer will use $RUST_SERVER_DIR internally
          ./install_rust_server.sh

      - name: Wait for StringPool dump
        run: |
          # Wait up to 5 minutes for plugin to write the JSON
          timeout 300 bash -c 'until [ -f "${RUST_SERVER_DIR}/oxide/data/stringpool_dump.json" ]; do sleep 5; done'

      - name: Stop Rust server
        run: |
          # Terminate the background server process
          kill "$(cat "${RUST_SERVER_DIR}/server.pid")" || true

      - name: Upload StringPool dump
        uses: actions/upload-artifact@v3
        with:
          name: stringpool-dump
          path: rust_server/oxide/data/stringpool_dump.json
