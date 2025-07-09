export default {
  pitstopApi: {
    input: {
      target: "http://localhost:5263/swagger/v1/swagger.json",
    },
    output: {
      workspace: "src/api/",
      target: "./endpoints/",
      schemas: "./types/",
      client: "axios",
      mode: "tags-split",
      mock: false,
      prettier: true,
      override: {
        // Custom instance
        mutator: {
          path: "./pitstopApiInstance.ts",
          name: "pitstopApiInstance",
        },
        title: (title) => `${title}Service`,
      },
    },
  },
}
