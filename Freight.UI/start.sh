#!/bin/bash

echo "Running npm install..."
npm install

echo "Starting Angular development server..."
node_modules/.bin/ng serve --host 0.0.0.0 --poll 1000
