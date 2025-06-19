// @ts-check
const eslint = require("@eslint/js");
const tseslint = require("typescript-eslint");
const angular = require("angular-eslint");

module.exports = tseslint.config(
  {
    files: ["**/*.ts"],
    extends: [
      eslint.configs.recommended,
      ...tseslint.configs.recommended,
      ...tseslint.configs.stylistic,
      ...angular.configs.tsRecommended,
    ],
    processor: angular.processInlineTemplates,
    rules: {
      "max-lines": ["error", 600],
      "max-lines-per-function": ["error", 150],
      "@typescript-eslint/consistent-type-definitions": "error",
      "@typescript-eslint/dot-notation": "off",
      "@typescript-eslint/explicit-member-accessibility": [
        "off",
        {
          accessibility: "explicit",
        },
      ],
      "@typescript-eslint/no-use-before-define": "error",
      "id-blacklist": "off",
      "id-match": "off",
      "no-underscore-dangle": "off",
      "no-unused-vars": "off",
      "no-console": "warn",
      "@typescript-eslint/no-unused-vars": ["error", { args: "none" }],
      "@angular-eslint/prefer-standalone": ["error"],
      "@angular-eslint/directive-selector": [
        "error",
        {
          type: "attribute",
          prefix: "app",
          style: "camelCase",
        },
      ],
      "@angular-eslint/component-selector": [
        "error",
        {
          type: "element",
          prefix: "app",
          style: "kebab-case",
        },
      ],
    },
  },
  {
    files: ["**/*.html"],
    extends: [
      ...angular.configs.templateRecommended,
      ...angular.configs.templateAccessibility,
    ],
    rules: {},
  }
);
