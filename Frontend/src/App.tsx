import { ThemeProvider } from 'styled-components'
import { Home } from './pages/Home'
import { GlobalStyle } from './styles/global'
import { defaultTheme } from './styles/themes/default'
import { JobProvider } from './hooks/JobContext'

export function App() {
  return (
    <ThemeProvider theme={defaultTheme}>
      <GlobalStyle />
      <JobProvider>
        <Home />
      </JobProvider>
    </ThemeProvider>
  )
}
