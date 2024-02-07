import * as React from 'react'
import Box from '@mui/material/Box'
import TabContext from '@mui/lab/TabContext'
import Tabs from '@mui/material/Tabs'
import Tab from '@mui/material/Tab'
import TabPanel from '@mui/lab/TabPanel'
import { InvitedCard } from '../../components/InvitedCard'
import { Grid } from '@mui/material'
import Services, { IJob } from './services'
import { AcceptedCard } from '../../components/AcceptedCard'

export function Home() {
  const [value, setValue] = React.useState('1')
  const [jobs, setJobs] = React.useState<IJob[] | []>([])

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    console.log(event)
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
              <Grid container>
                {jobs?.map((item) => {
                  return (
                    <Grid item xs={12} key={item?.id} margin={1}>
                      <InvitedCard
                        key={item?.id}
                        category={item?.category}
                        createdAt={item?.createdAt}
                        description={item?.description}
                        name={item?.client.name.split(' ')[0]}
                        price={item?.price}
                        suburb={item?.client.suburb}
                        id={item?.id}
                      />
                    </Grid>
                  )
                })}
              </Grid>
            </TabPanel>
            <TabPanel value="2" style={{ background: 'rgb(239 239 239)' }}>
              <Grid container>
                {jobs?.map((item) => {
                  return (
                    <Grid item xs={12} key={item?.id} margin={1}>
                      <AcceptedCard
                        key={item?.id}
                        category={item?.category}
                        createdAt={item?.createdAt}
                        description={item?.description}
                        name={item?.client.name}
                        price={item?.price}
                        suburb={item?.client.suburb}
                        id={item?.id}
                        email={item.client.email}
                        phone={item.client.phoneNumber}
                      />
                    </Grid>
                  )
                })}
              </Grid>
            </TabPanel>
          </TabContext>
        </Box>
      </Grid>
      <Grid item xs={2} />
    </Grid>
  )
}
