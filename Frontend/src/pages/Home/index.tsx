import * as React from 'react'
import Box from '@mui/material/Box'
import TabContext from '@mui/lab/TabContext'
import Tabs from '@mui/material/Tabs'
import Tab from '@mui/material/Tab'
import TabPanel from '@mui/lab/TabPanel'
import { InvitedCard } from '../../components/InvitedCard'
import { Grid } from '@mui/material'
import Services, { IJob } from './services'

export function Home() {
  const [value, setValue] = React.useState('1')
  const [jobs, setJobs] = React.useState<IJob[] | []>([])

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue)
  }

  const GetJobs = async () => {
    const services = new Services()
    const status = Number.parseInt(value) - 1
    const { error, response } = await services.GetByStatus(status.toString())
    console.log(response)
    if (!error && response) setJobs(response)
  }

  React.useEffect(() => {
    GetJobs()
  }, [value])

  return (
    <Grid container>
      <Grid item xs={2} />
      <Grid item xs={8} xl={8} style={{ backgroundColor: 'white' }}>
        <Box sx={{ width: '100%', typography: 'body1' }}>
          <TabContext value={value}>
            <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
              <Tabs
                onChange={handleChange}
                aria-label="lab API tabs example"
                value={value}
                variant="fullWidth"
              >
                <Tab label="Invited" value="1" />
                <Tab label="Accepted" value="2" />
              </Tabs>
            </Box>
            <TabPanel value="1" style={{ background: 'rgb(239 239 239)' }}>
              {jobs?.map((item) => {
                console.log(item)
                return (
                  <InvitedCard
                    key={item?.id}
                    category={item?.category}
                    createdAt={item?.createdAt}
                    description={item?.description}
                    name={item?.client.name}
                    price={item?.price}
                    suburb={item?.client.suburb}
                    id={item?.id}
                  />
                )
              })}
            </TabPanel>
            <TabPanel value="2">Item Two</TabPanel>
          </TabContext>
        </Box>
      </Grid>
      <Grid item xs={2} />
    </Grid>
  )
}
