import { createGlobalStyle } from 'styled-components'

export const GlobalStyle = createGlobalStyle`
  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  :focus {
    outline: 0;
  }

  input:focus {
    box-shadow: 0 0 0 2px ${(props) => props.theme['green-500']};
  }

  body {
    color: ${(props) => props.theme['gray-900']};
    background-color: ${(props) => props.theme['gray-800']};
    -webkit-font-smoothing: antialiased;
  }

  body, input, textarea, button {
    font: 400 1rem Roboto, sans-serif;
  }

  button {
    cursor: pointer;
  }

  .css-1aquho2-MuiTabs-indicator{
    background-color: orange;
  }
  .css-1ujykiq-MuiButtonBase-root-MuiTab-root.Mui-selected{
    color: #000 !important;
    font-weight: 500;
  }

  .css-1fu7jd5-MuiButtonBase-root-MuiButton-root{
    background-color: #ffbc41;
    color: #000;

    &:hover{
      background-color: #ffa500;
      font-weight: bold;
    }
  }
  
`
