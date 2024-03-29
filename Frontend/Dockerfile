FROM node:18-alpine as dependencies

# Set HOME path and fix npm red false-positive
ENV HOME=/home/node

EXPOSE 3000
EXPOSE 5173

# Install depencies
COPY ./Frontend $HOME/node_docker/
WORKDIR $HOME/node_docker/
RUN yarn install --force
RUN yarn build

# Build releade
FROM node:18-alpine

# Set HOME path
ENV HOME=/home/node

# Copy node_modules
COPY --from=dependencies /home/node/node_docker/node_modules $HOME/node_modules

# Copy application
COPY --from=dependencies /home/node/node_docker/dist $HOME/dist
COPY --from=dependencies /home/node/node_docker/package.json $HOME
COPY --from=dependencies /home/node/node_docker/public $HOME/public
COPY --from=dependencies /home/node/node_docker/tsconfig.json $HOME
COPY --from=dependencies /home/node/node_docker/vite.config.ts $HOME
COPY --from=dependencies /home/node/node_docker/tsconfig.node.json $HOME
COPY --from=dependencies /home/node/node_docker/.eslintrc.json $HOME
COPY --from=dependencies /home/node/node_docker/index.html $HOME
COPY --from=dependencies /home/node/node_docker/src $HOME/src

# Run with node user
RUN chown -R node:node $HOME
USER node
WORKDIR $HOME


CMD ["yarn", "dev","--port", "3000", "--debug"]